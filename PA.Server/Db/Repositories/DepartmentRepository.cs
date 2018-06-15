using PA.Server.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Server.Db.Repositories
{
    public class DepartmentRepository : IRepository<Department, int>
    {
        private PaDbContext _db;

        public DepartmentRepository(PaDbContext db)
        {
            _db = db;
        }

        public Department Create(Department item)
        {
            var result = _db.Departments.Add(new Department
            {
                EmployeeHeadId = -1,
                Name = item.Name,
                Situation = " "
            });
            _db.SaveChanges();

            return result;
        }

        public Department Delete(Department item)
        {
            var dep = _db.Departments
                               .Where(x => x.Id == item.Id)
                               .FirstOrDefault();

            _db.Departments.Remove(dep);
            _db.SaveChanges();

            return dep;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public Department Get(int id)
        {
            return _db.Departments
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Department> GetAll()
        {
            return _db.Departments.Select(x => x);
        }

        public void Update(Department item)
        {
            var depToUpdate = _db.Departments
                .Where(x => x.Id == item.Id)
                .FirstOrDefault();

            _db.Entry(depToUpdate).CurrentValues.SetValues(item);
            _db.SaveChanges();
        }
    }
}
