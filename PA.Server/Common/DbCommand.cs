using PA.Core;
using PA.Core.Models;
using PA.Server.Db;
using PA.Server.Db.Entities;
using PA.Server.Db.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PA.Server.Common
{
    public class DbCommand : Command
    {
        private DepartmentRepository depsRepo;
        private EmployeeRepository empsRepo;
        private PayoutRepository payoutsRepo;
        private PayoutTypeRepository payoutTypesRepo;
        private PositionRepository positionsRepo;

        private RequestTypes _command;

        private NetworkStream _stream;

        public DbCommand(PaDbContext context, RequestTypes command, NetworkStream stream)
        {
            _command = command;
            _stream = stream;
            depsRepo = new DepartmentRepository(context);
            positionsRepo = new PositionRepository(context);
            empsRepo = new EmployeeRepository(context);
            payoutTypesRepo = new PayoutTypeRepository(context);
            payoutsRepo = new PayoutRepository(context);
        }

        public override void Execute()
        {
            IFormatter formatter = new BinaryFormatter();

            switch (_command)
            {
                case RequestTypes.EditPosition:
                    {
                        LoggerEvs.writeLog("Edit position");

                        var posModel = (PositionModel)formatter.Deserialize(_stream);

                        var pos = positionsRepo.Get(posModel.Id);

                        pos.Name = posModel.Name;
                        positionsRepo.Update(pos);

                        formatter.Serialize(_stream, ResponseTypes.Data);

                        LoggerEvs.writeLog("Position updated");
                        break;
                    }
                case RequestTypes.RemovePosition:
                    {
                        LoggerEvs.writeLog("Remove position");

                        var posId = (int)formatter.Deserialize(_stream);

                        var position = positionsRepo.Get(posId);
                        positionsRepo.Delete(position);

                        formatter.Serialize(_stream, ResponseTypes.Data);

                        LoggerEvs.writeLog("Position removed");
                        break;
                    }
                case RequestTypes.CreatePosition:
                    {
                        LoggerEvs.writeLog("Creating position");

                        var positionModel = (PositionModel)formatter.Deserialize(_stream);

                        positionsRepo.Create(new Position
                        {
                            Name = positionModel.Name,
                            Salary = 1
                        });

                        formatter.Serialize(_stream, ResponseTypes.Data);

                        LoggerEvs.writeLog("Position created");
                        break;
                    }
                case RequestTypes.CreateDep:
                    {
                        LoggerEvs.writeLog("Create department");

                        var depModel = (DepartmentModel)formatter.Deserialize(_stream);

                        depsRepo.Create(new Department
                        {
                            EmployeeHeadId = -1,
                            Name = depModel.Name,
                            Situation = " "
                        });

                        formatter.Serialize(_stream, ResponseTypes.Data);

                        LoggerEvs.writeLog("Department created");
                        break;
                    }
                case RequestTypes.EditDepartment:
                    {
                        LoggerEvs.writeLog("Edit department");

                        var depModel = (DepartmentModel)formatter.Deserialize(_stream);

                        var updates = new Department
                        {
                            EmployeeHeadId = -1,
                            Id = depModel.Id,
                            Name = depModel.Name,
                            Situation = ""
                        };

                        depsRepo.Update(updates);
                        formatter.Serialize(_stream, ResponseTypes.Data);

                        LoggerEvs.writeLog("Department updated");
                        break;
                    }
                case RequestTypes.RemoveDep:
                    {
                        LoggerEvs.writeLog("Remove department");

                        var depId = (int)formatter.Deserialize(_stream);

                        var dep = depsRepo.Get(depId);
                        depsRepo.Delete(dep);

                        formatter.Serialize(_stream, ResponseTypes.Data);

                        LoggerEvs.writeLog("Department removed");
                        break;
                    }
                case RequestTypes.EditPayout:
                    {
                        LoggerEvs.writeLog("Update payout");

                        var payoutEditModel = (EditPayoutModel)formatter.Deserialize(_stream);

                        var payout = payoutsRepo.Get(payoutEditModel.PayoutId);

                        payout.Sum = payoutEditModel.Sum;

                        payoutsRepo.Update(payout);

                        formatter.Serialize(_stream, new PayoutModel
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

                        var payoutId = (int)formatter.Deserialize(_stream);
                        var payout = payoutsRepo.Get(payoutId);
                        payoutsRepo.Delete(payout);

                        formatter.Serialize(_stream, ResponseTypes.Data);

                        LoggerEvs.writeLog("Payout removed");
                        break;
                    }
                case RequestTypes.GetPayouts:
                    {
                        LoggerEvs.writeLog("Get payouts");

                        var empId = (int)formatter.Deserialize(_stream);

                        var payouts = payoutsRepo.GetAll()
                            .Where(x => x.EmployeeId == empId)
                            .Join(payoutTypesRepo.GetAll(), x => x.PayoutTypeId, y => y.Id, (x, y) => new PayoutModel
                            {
                                Id = x.Id,
                                PayoutType = y.Name,
                                Sum = x.Sum
                            })
                            .ToList();

                        formatter.Serialize(_stream, payouts);

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

                        formatter.Serialize(_stream, ResponseTypes.Data);
                        formatter.Serialize(_stream, payoutTypes);

                        LoggerEvs.writeLog("Payout types sent");
                        break;
                    }
                case RequestTypes.CreatePayout:
                    {
                        LoggerEvs.writeLog("Assign payout");

                        var assignPayout = (AssignPayoutModel)formatter.Deserialize(_stream);

                        var payout = payoutsRepo.Create(new Payout()
                        {
                            EmployeeId = assignPayout.EmployeeId,
                            PayoutTypeId = assignPayout.PayoutTypeId,
                            Sum = assignPayout.Sum
                        });

                        formatter.Serialize(_stream, ResponseTypes.Data);
                        formatter.Serialize(_stream, payout.Id);

                        LoggerEvs.writeLog("Payout assigned");
                        break;
                    }
                case RequestTypes.FireEmp:
                    {
                        LoggerEvs.writeLog("Fire emp");

                        var empId = (int)formatter.Deserialize(_stream);

                        var emp = empsRepo.Get(empId);
                        empsRepo.Delete(emp);

                        formatter.Serialize(_stream, ResponseTypes.Data);
                        formatter.Serialize(_stream, empId);

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

                    formatter.Serialize(_stream, ResponseTypes.Data);
                    formatter.Serialize(_stream, deps);

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

                    formatter.Serialize(_stream, ResponseTypes.Data);
                    formatter.Serialize(_stream, positions);

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

                    formatter.Serialize(_stream, ResponseTypes.Data);

                    formatter.Serialize(_stream, emps);
                    LoggerEvs.writeLog("Emps sent");
                    break;
                case RequestTypes.EditEmp:
                    {
                        LoggerEvs.writeLog("Edit emp request");
                        var empFromRequuest = (EmployeeEditModel)formatter.Deserialize(_stream);

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

                            formatter.Serialize(_stream, ResponseTypes.Data);

                            // Отправить обновленную информацию на клиент
                            formatter.Serialize(_stream, new EmployeeModel
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
                            formatter.Serialize(_stream, ResponseTypes.Error);
                            formatter.Serialize(_stream, ex.Message);
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    }
                case RequestTypes.CreateEmp:
                    LoggerEvs.writeLog("Create emp request");
                    var newEmpModel = (EmployeeModel)formatter.Deserialize(_stream);

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

                        formatter.Serialize(_stream, ResponseTypes.Data);
                        formatter.Serialize(_stream, new EmployeeModel
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
                        formatter.Serialize(_stream, ResponseTypes.Error);
                        formatter.Serialize(_stream, ex.Message);
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case RequestTypes.CreatePayoutType:
                    LoggerEvs.writeLog("Create payout type request");
                    var newPayoutTypeModel = (PayoutTypeModel)formatter.Deserialize(_stream);

                    try
                    {
                        payoutTypesRepo.Create(new PayoutType
                        {
                            Name = newPayoutTypeModel.Name
                        });

                        formatter.Serialize(_stream, ResponseTypes.Data);

                        LoggerEvs.writeLog("Payout type created");
                    }
                    catch (Exception ex)
                    {
                        formatter.Serialize(_stream, ResponseTypes.Error);
                        formatter.Serialize(_stream, ex.Message);
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case RequestTypes.EditPayoutType:
                    {
                        LoggerEvs.writeLog("Edit payout type");

                        var payoutType = (PayoutTypeModel)formatter.Deserialize(_stream);

                        var pt = payoutTypesRepo.Get(payoutType.Id);

                        pt.Name = payoutType.Name;

                        payoutTypesRepo.Update(pt);

                        formatter.Serialize(_stream, ResponseTypes.Data);

                        LoggerEvs.writeLog("Payout type updated");
                        break;
                    }
                case RequestTypes.RemovePayoutType:
                    {
                        LoggerEvs.writeLog("Remove payout type");

                        var payoutTypeId = (int)formatter.Deserialize(_stream);

                        var payoutType = payoutTypesRepo.Get(payoutTypeId);
                        payoutTypesRepo.Delete(payoutType);

                        formatter.Serialize(_stream, ResponseTypes.Data);

                        LoggerEvs.writeLog("Payout type removed");
                        break;
                    }
            }
        }
    }
}
