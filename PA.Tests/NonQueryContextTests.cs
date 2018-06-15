using System;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PA.Server.Db;
using PA.Server.Db.Entities;
using PA.Server.Db.Repositories;

namespace PA.Tests
{
    [TestClass]
    public class NonQueryContextTests
    {
        [TestMethod]
        public void CreateDepartmentSavesADepartmentViaContext()
        {
            var mockSet = new Mock<DbSet<Department>>();

            var mockContext = new Mock<PaDbContext>();
            mockContext.Setup(m => m.Departments).Returns(mockSet.Object);

            var depsRepo = new DepartmentRepository(mockContext.Object);
            depsRepo.Create(new Department
            {
                EmployeeHeadId = -1,
                Name = "Test Dep",
                Situation = ""
            });

            mockSet.Verify(m => m.Add(It.IsAny<Department>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
