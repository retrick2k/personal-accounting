using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PA.Server.Db;
using PA.Server.Db.Entities;
using PA.Server.Db.Repositories;

namespace PA.Tests
{
    [TestClass]
    public class DepartmentRepositoryQueryTests
    {
        [TestMethod]
        public void GetAll()
        {
            var data = new List<Department>()
            {
                new Department
                {
                    EmployeeHeadId = -1,
                    Id = 1,
                    Name = "Dep 1",
                    Situation = ""
                },
                new Department
                {
                    EmployeeHeadId = -1,
                    Id = 2,
                    Name = "Dep 2",
                    Situation = ""
                },
                new Department
                {
                    EmployeeHeadId = -1,
                    Id = 3,
                    Name = "Dep 3",
                    Situation = ""
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Department>>();
            mockSet.As<IQueryable<Department>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Department>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Department>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Department>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<PaDbContext>();
            mockContext.Setup(x => x.Departments).Returns(mockSet.Object);

            var repo = new DepartmentRepository(mockContext.Object);
            var deps = repo.GetAll().ToList();

            Assert.AreEqual(1, deps[0].Id);
            Assert.AreEqual(2, deps[1].Id);
            Assert.AreEqual(3, deps[2].Id);
        }

        [TestMethod]
        public void Get()
        {
            var data = new List<Department>()
            {
                new Department
                {
                    EmployeeHeadId = -1,
                    Id = 1,
                    Name = "Dep 1",
                    Situation = ""
                },
                new Department
                {
                    EmployeeHeadId = -1,
                    Id = 2,
                    Name = "Dep 2",
                    Situation = ""
                },
                new Department
                {
                    EmployeeHeadId = -1,
                    Id = 3,
                    Name = "Dep 3",
                    Situation = ""
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Department>>();
            mockSet.As<IQueryable<Department>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Department>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Department>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Department>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<PaDbContext>();
            mockContext.Setup(x => x.Departments).Returns(mockSet.Object);

            var repo = new DepartmentRepository(mockContext.Object);
            var dep = repo.Get(2);

            Assert.AreEqual(2, dep.Id);
            Assert.AreEqual("Dep 2", dep.Name);
        }

        [TestMethod]
        public void Update()
        {
            var data = new List<Department>()
            {
                new Department
                {
                    EmployeeHeadId = -1,
                    Id = 1,
                    Name = "Dep 1",
                    Situation = ""
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Department>>();
            mockSet.As<IQueryable<Department>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Department>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Department>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Department>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            
            var mockContext = new Mock<PaDbContext>();
            mockContext.Setup(x => x.Departments).Returns(mockSet.Object);
            mockContext.Setup(x => x.SaveChanges()).Returns(1);

            var repo = new DepartmentRepository(mockContext.Object);
            repo.Update(new Department
            {
                Id = 1,
                Name = "Dep 2 updated"
            });

            var updated = repo.Get(1);

            Assert.AreEqual(1, updated.Id);
            Assert.AreEqual("Dep 2 updated", updated.Name);
        }
    }
}
