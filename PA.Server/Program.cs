﻿using PA.Core;
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
                    dispatchRequest(request, clientStream, formatter);
                }
                catch (Exception ex)
                {
                    LoggerEvs.writeLog("Connection closed");
                    clients.Remove(clientId);
                    break;
                }
            }
        }

        private static void dispatchRequest(RequestTypes request, NetworkStream stream, IFormatter formatter)
        {            
            using (var context = new PaDbContext())
            {
                var depsRepo = new DepartmentRepository(context);
                var positionsRepo = new PositionRepository(context);
                var empsRepo = new EmployeeRepository(context);
                var payoutTypesRepo = new PayoutTypeRepository(context);
                var payoutsRepo = new PayoutRepository(context);

                switch (request)
                {
                    case RequestTypes.EditPosition:
                        {
                            LoggerEvs.writeLog("Edit position");

                            var posModel = (PositionModel)formatter.Deserialize(stream);

                            var pos = positionsRepo.Get(posModel.Id);

                            pos.Name = posModel.Name;
                            positionsRepo.Update(pos);

                            formatter.Serialize(stream, ResponseTypes.Data);

                            LoggerEvs.writeLog("Position updated");
                            break;
                        }
                    case RequestTypes.RemovePosition:
                        {
                            LoggerEvs.writeLog("Remove position");

                            var posId = (int)formatter.Deserialize(stream);

                            var position = positionsRepo.Get(posId);
                            positionsRepo.Delete(position);

                            formatter.Serialize(stream, ResponseTypes.Data);

                            LoggerEvs.writeLog("Position removed");
                            break;
                        }
                    case RequestTypes.CreatePosition:
                        {
                            LoggerEvs.writeLog("Creating position");

                            var positionModel = (PositionModel)formatter.Deserialize(stream);

                            positionsRepo.Create(new Position
                            {
                                Name = positionModel.Name,
                                Salary = 1
                            });

                            formatter.Serialize(stream, ResponseTypes.Data);

                            LoggerEvs.writeLog("Position created");
                            break;
                        }
                    case RequestTypes.CreateDep:
                        {
                            LoggerEvs.writeLog("Create department");

                            var depModel = (DepartmentModel)formatter.Deserialize(stream);

                            depsRepo.Create(new Department
                            {
                                EmployeeHeadId = -1,
                                Name = depModel.Name,
                                Situation = " "
                            });

                            formatter.Serialize(stream, ResponseTypes.Data);

                            LoggerEvs.writeLog("Department created");
                            break;
                        }
                    case RequestTypes.EditDepartment:
                        {
                            LoggerEvs.writeLog("Edit department");

                            var depModel = (DepartmentModel)formatter.Deserialize(stream);

                            var updates = new Department
                            {
                                EmployeeHeadId = -1,
                                Id = depModel.Id,
                                Name = depModel.Name,
                                Situation = ""
                            };

                            depsRepo.Update(updates);
                            formatter.Serialize(stream, ResponseTypes.Data);

                            LoggerEvs.writeLog("Department updated");
                            break;
                        }
                    case RequestTypes.RemoveDep:
                        {
                            LoggerEvs.writeLog("Remove department");

                            var depId = (int)formatter.Deserialize(stream);

                            var dep = depsRepo.Get(depId);
                            depsRepo.Delete(dep);

                            formatter.Serialize(stream, ResponseTypes.Data);

                            LoggerEvs.writeLog("Department removed");
                            break;
                        }
                    case RequestTypes.EditPayout:
                        {
                            LoggerEvs.writeLog("Update payout");

                            var payoutEditModel = (EditPayoutModel)formatter.Deserialize(stream);

                            var payout = payoutsRepo.Get(payoutEditModel.PayoutId);

                            payout.Sum = payoutEditModel.Sum;

                            payoutsRepo.Update(payout);

                            formatter.Serialize(stream, new PayoutModel
                            {
                                Id = payout.Id,
                                Sum = payout.Sum
                            });

                            LoggerEvs.writeLog("Payout updated");
                            break;
                        }
                    case RequestTypes.RemovePayout:
                        {
                            LoggerEvs.writeLog("Remove payout");

                            var payoutId = (int)formatter.Deserialize(stream);
                            var payout = payoutsRepo.Get(payoutId);
                            payoutsRepo.Delete(payout);

                            formatter.Serialize(stream, ResponseTypes.Data);

                            LoggerEvs.writeLog("Payout removed");
                            break;
                        }
                    case RequestTypes.GetPayouts:
                        {
                            LoggerEvs.writeLog("Get payouts");

                            var empId = (int)formatter.Deserialize(stream);

                            var payouts = payoutsRepo.GetAll()
                                .Where(x => x.EmployeeId == empId)
                                .Join(payoutTypesRepo.GetAll(), x => x.PayoutTypeId, y => y.Id, (x, y) => new PayoutModel
                                {
                                    Id = x.Id,
                                    PayoutType = y.Name,
                                    Sum = x.Sum
                                })
                                .ToList();

                            formatter.Serialize(stream, payouts);

                            LoggerEvs.writeLog("Payouts sent");
                            break;
                        }
                    case RequestTypes.GetPayoutTypes:
                        {
                            LoggerEvs.writeLog("Get payout types");

                            var payoutTypes = payoutTypesRepo.GetAll()
                                .Select(x => new PayoutTypeModel
                                {
                                    Id = x.Id,
                                    Name = x.Name
                                })
                                .ToList();

                            formatter.Serialize(stream, ResponseTypes.Data);
                            formatter.Serialize(stream, payoutTypes);

                            LoggerEvs.writeLog("Payout types sent");
                            break;
                        }
                    case RequestTypes.CreatePayout:
                        {
                            LoggerEvs.writeLog("Assign payout");

                            var assignPayout = (AssignPayoutModel)formatter.Deserialize(stream);

                            var payout = payoutsRepo.Create(new Payout()
                            {
                                EmployeeId = assignPayout.EmployeeId,
                                PayoutTypeId = assignPayout.PayoutTypeId,
                                Sum = assignPayout.Sum
                            });

                            formatter.Serialize(stream, ResponseTypes.Data);
                            formatter.Serialize(stream, payout.Id);

                            LoggerEvs.writeLog("Payout assigned");
                            break;
                        }
                    case RequestTypes.FireEmp:
                        {
                            LoggerEvs.writeLog("Fire emp");

                            var empId = (int)formatter.Deserialize(stream);

                            var emp = empsRepo.Get(empId);
                            empsRepo.Delete(emp);

                            formatter.Serialize(stream, ResponseTypes.Data);
                            formatter.Serialize(stream, empId);

                            LoggerEvs.writeLog("Emp fired");
                            break;
                        }
                    case RequestTypes.GetDepartments:
                        LoggerEvs.writeLog("Get departments");

                        var deps = depsRepo.GetAll()
                            .Select(x => new DepartmentModel
                            {
                                Id = x.Id,
                                Name = x.Name
                            })
                            .ToList();

                        formatter.Serialize(stream, ResponseTypes.Data);
                        formatter.Serialize(stream, deps);

                        LoggerEvs.writeLog("Departments sent");
                        break;
                    case RequestTypes.GetPositions:
                        LoggerEvs.writeLog("Get positions");

                        var positions = positionsRepo.GetAll()
                        .Select(x => new PositionModel
                        {
                            Id = x.Id,
                            Name = x.Name
                        })
                        .ToList();

                        formatter.Serialize(stream, ResponseTypes.Data);
                        formatter.Serialize(stream, positions);

                        LoggerEvs.writeLog("Positions sent");
                        break;
                    case RequestTypes.GetEmps:
                        LoggerEvs.writeLog("Get emps request");
                        var emps = empsRepo.GetAll()
                        .Join(positionsRepo.GetAll(), x => x.PositionId, y => y.Id, (x, y) => new
                        {
                            Id = x.Id,
                            FirstName = x.FirstName,
                            LastName = x.LastName,
                            MiddleName = x.MiddleName,
                            Position = y.Name,
                            DepartmentId = x.DepartmentId
                        })
                        .Join(depsRepo.GetAll(), x => x.DepartmentId, y => y.Id, (x, y) => new EmployeeModel
                        {
                            Department = y.Name,
                            Id = x.Id,
                            FirstName = x.FirstName,
                            LastName = x.LastName,
                            MiddleName = x.MiddleName,
                            Position = x.Position
                        })
                        .ToList();

                        formatter.Serialize(stream, ResponseTypes.Data);

                        formatter.Serialize(stream, emps);
                        LoggerEvs.writeLog("Emps sent");
                        break;
                    case RequestTypes.EditEmp:
                        {
                            LoggerEvs.writeLog("Edit emp request");
                            var empFromRequuest = (EmployeeEditModel)formatter.Deserialize(stream);

                            try
                            {
                                var position = positionsRepo.Get(empFromRequuest.PositionId);

                                var dep = depsRepo.Get(empFromRequuest.DepartmentId);

                                var emp = empsRepo.Get(empFromRequuest.Id);

                                emp.LastName = empFromRequuest.LastName;
                                emp.MiddleName = empFromRequuest.MiddleName;
                                emp.FirstName = empFromRequuest.FirstName;
                                emp.DepartmentId = dep.Id;
                                emp.PositionId = position.Id;

                                empsRepo.Update(emp);

                                formatter.Serialize(stream, ResponseTypes.Data);

                                // Отправить обновленную информацию на клиент
                                formatter.Serialize(stream, new EmployeeModel
                                {
                                    Id = emp.Id,
                                    FirstName = emp.FirstName,
                                    LastName = emp.LastName,
                                    MiddleName = emp.LastName,
                                    Department = dep.Name,
                                    Position = position.Name
                                });
                                LoggerEvs.writeLog("Emp updated, sending actual info");
                            }
                            catch (Exception ex)
                            {
                                formatter.Serialize(stream, ResponseTypes.Error);
                                formatter.Serialize(stream, ex.Message);
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }
                    case RequestTypes.CreateEmp:
                        LoggerEvs.writeLog("Create emp request");
                        var newEmpModel = (EmployeeModel)formatter.Deserialize(stream);

                        try
                        {
                            var position = positionsRepo.GetAll()
                                .Where(x => x.Name == newEmpModel.Position)
                                .FirstOrDefault();

                            var dept = depsRepo.GetAll()
                                .Where(x => x.Name == newEmpModel.Department)
                                .FirstOrDefault();

                            var emp = new Employee
                            {
                                FirstName = newEmpModel.FirstName,
                                LastName = newEmpModel.LastName,
                                MiddleName = newEmpModel.MiddleName,
                                PositionId = position.Id,
                                DepartmentId = dept.Id
                            };

                            emp = empsRepo.Create(emp);

                            formatter.Serialize(stream, ResponseTypes.Data);
                            formatter.Serialize(stream, new EmployeeModel
                            {
                                FirstName = emp.FirstName,
                                LastName = emp.LastName,
                                Id = emp.Id,
                                MiddleName = emp.MiddleName,
                                Position = position.Name,
                                Department = dept.Name
                            });

                            LoggerEvs.writeLog("Emp created");
                        }
                        catch (Exception ex)
                        {
                            formatter.Serialize(stream, ResponseTypes.Error);
                            formatter.Serialize(stream, ex.Message);
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case RequestTypes.CreatePayoutType:
                        LoggerEvs.writeLog("Create payout type request");
                        var newPayoutTypeModel = (PayoutTypeModel)formatter.Deserialize(stream);

                        try
                        {
                            payoutTypesRepo.Create(new PayoutType
                            {
                                Name = newPayoutTypeModel.Name
                            });

                            formatter.Serialize(stream, ResponseTypes.Data);

                            LoggerEvs.writeLog("Payout type created");
                        }
                        catch (Exception ex)
                        {
                            formatter.Serialize(stream, ResponseTypes.Error);
                            formatter.Serialize(stream, ex.Message);
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case RequestTypes.EditPayoutType:
                        {
                            LoggerEvs.writeLog("Edit payout type");

                            var payoutType = (PayoutTypeModel)formatter.Deserialize(stream);

                            var pt = payoutTypesRepo.Get(payoutType.Id);

                            pt.Name = payoutType.Name;

                            payoutTypesRepo.Update(pt);

                            formatter.Serialize(stream, ResponseTypes.Data);

                            LoggerEvs.writeLog("Payout type updated");
                            break;
                        }
                    case RequestTypes.RemovePayoutType:
                        {
                            LoggerEvs.writeLog("Remove payout type");

                            var payoutTypeId = (int)formatter.Deserialize(stream);

                            var payoutType = payoutTypesRepo.Get(payoutTypeId);
                            payoutTypesRepo.Delete(payoutType);

                            formatter.Serialize(stream, ResponseTypes.Data);

                            LoggerEvs.writeLog("Payout type removed");
                            break;
                        }
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
