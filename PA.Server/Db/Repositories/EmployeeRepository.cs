using PA.Server.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Server.Db.Repositories
{
    public class EmployeeRepository : IRepository<Employee, int>
    {
        private PaDbContext _db;

        public EmployeeRepository(PaDbContext db)
        {
            _db = db;
        }

        public Employee Create(Employee item)
        {
            var result = _db.Employees.Add(item);
            _db.SaveChanges();

            return result;
        }

        public Employee Delete(Employee item)
        {
            var result = _db.Employees.Remove(item);
            _db.SaveChanges();

            return result;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public Employee Get(int id)
        {
            return _db.Employees
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _db.Employees.Select(x => x);
        }

        public void Update(Employee item)
        {
            _db.Entry(item).CurrentValues.SetValues(item);
            _db.SaveChanges();
        }
    }
}
