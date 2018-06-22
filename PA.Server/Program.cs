using PA.Core;
using PA.Core.Models;
using PA.Server.Common;
using PA.Server.Db;
using PA.Server.Db.Entities;
using PA.Server.Db.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PA.Server
{
    class Program
    {
        /// <summary>
        /// Глобальный Id клиентов
        /// </summary>
        static int globalClientsId = 0;

        /// <summary>
        /// Коллекция подключенных клиентов
        /// </summary>
        static Dictionary<int, Client> clients = new Dictionary<int, Client>();

        static PaDbContext context = new PaDbContext();

        static void Main(string[] args)
        {
            //InitDb();
            Console.Title = "Personal accounting server:2018";
            const int receiveTimeout = 60 * 100000;
            const int sendTimeout = 60 * 100000;

            LoggerEvs.messageCame += logToConsole;

            const int port = 11000;

            TcpListener tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();
            LoggerEvs.writeLog($"Listening started on port: {port}");

            TcpClient client;
            Thread thread;

            while (true)
            {
                client = tcpListener.AcceptTcpClient();
                LoggerEvs.writeLog("New client accepted!");

                client.SendTimeout = sendTimeout;
                client.ReceiveTimeout = receiveTimeout;

                int id = globalClientsId++;

                thread = new Thread(delegate () { requestsHandler(id); });
                Client newClient = new Client
                {
                    Id = id,
                    TcpClient = client,
                    Thread = thread
                };

                clients.Add(id, newClient);
                clients[id].Thread.Start();
            }
        }

        private static void logToConsole(string msg)
        {
            Console.Write(msg);
        }

        /// <summary>
        /// Обработчик запросов
        /// </summary>
        /// <param name="clientId">Id клиента</param>
        private static void requestsHandler(int clientId)
        {
            IFormatter formatter = new BinaryFormatter();

            // Получить поток клиента
            NetworkStream clientStream = clients[clientId].TcpClient.GetStream();

            // Обработка запросов
            while (true)
            {
                // Получить запрос
                try
                {
                    var request = (RequestTypes)formatter.Deserialize(clientStream);

                    Command command = new DbCommand(context, request, clientStream);
                    command.Execute();
                }
                catch (Exception ex)
                {
                    LoggerEvs.writeLog("Connection closed");
                    clients.Remove(clientId);
                    break;
                }
            }
        }

        private static void InitDb()
        {
            using (var context = new PaDbContext())
            {
                // Добавить типы выплат
                context.PayoutTypes.Add(new PayoutType { Name = "Зарплата" });
                context.PayoutTypes.Add(new PayoutType { Name = "Премия" });
                context.PayoutTypes.Add(new PayoutType { Name = "Выходное пособие" });
                context.PayoutTypes.Add(new PayoutType { Name = "Помощь от профкома" });
                context.PayoutTypes.Add(new PayoutType { Name = "Отпускные" });
                context.PayoutTypes.Add(new PayoutType { Name = "Премия за приглашенного сотрудника" });
                context.PayoutTypes.Add(new PayoutType { Name = "Процент от стоимости проекта" });
                context.PayoutTypes.Add(new PayoutType { Name = "Декретная выплата" });

                // Сохранить изменения
                context.SaveChanges();

                // Добавить должности
                context.Positions.Add(new Position { Name = "Генеральный директор", Salary = 100000 });
                context.Positions.Add(new Position { Name = "Заместитель ген. директора", Salary = 90000 });
                context.Positions.Add(new Position { Name = "Начальник отдела продаж", Salary = 55000 });
                context.Positions.Add(new Position { Name = "Главный инженер проекта", Salary = 45000 });
                context.Positions.Add(new Position { Name = "Ведущий инженер", Salary = 20000 });
                context.Positions.Add(new Position { Name = "Стажер", Salary = 8500 });
                context.Positions.Add(new Position { Name = "Начальник службы безопасности", Salary = 80000 });
                context.Positions.Add(new Position { Name = "Охранник", Salary = 30000 });

                // Сохранить изменения
                context.SaveChanges();

                // Добавить отделы компании
                var salesDept = new Department { Name = "Отдел продаж", EmployeeHeadId = -1, Situation = "Второй этаж" };
                var headDept = new Department { Name = "Офис директора", EmployeeHeadId = -1, Situation = "Пентхаус" };
                var securityDept = new Department { Name = "Служба безопасности", EmployeeHeadId = -1, Situation = "Первый этаж" };

                context.Departments.Add(salesDept);
                context.Departments.Add(headDept);
                context.Departments.Add(securityDept);

                context.SaveChanges();

                // Добавить сотрудников
                var headId = context.Positions
                    .Where(x => x.Name == "Генеральный директор")
                    .Select(x => x.Id)
                    .FirstOrDefault();
                context.Employees.Add(new Employee
                {
                    FirstName = "Николай",
                    LastName = "Иванов",
                    MiddleName = "Петрович",
                    PositionId = headId,
                    DepartmentId = headDept.Id
                });

                var salesDepartmentHeadId = context.Positions
                    .Where(x => x.Name == "Начальник отдела продаж")
                    .Select(x => x.Id)
                    .FirstOrDefault();
                context.Employees.Add(new Employee
                {
                    FirstName = "Виталий",
                    LastName = "Петров",
                    MiddleName = "Павлович",
                    PositionId = salesDepartmentHeadId,
                    DepartmentId = salesDept.Id
                });

                var guardId = context.Positions
                    .Where(x => x.Name == "Начальник службы безопасности")
                    .Select(x => x.Id)
                    .FirstOrDefault();
                context.Employees.Add(new Employee
                {
                    FirstName = "Алексей",
                    LastName = "Федоров",
                    MiddleName = "Аркадьевич",
                    PositionId = guardId,
                    DepartmentId = securityDept.Id
                });

                // Сохранить изменения
                context.SaveChanges();
            }
        }
    }
}
