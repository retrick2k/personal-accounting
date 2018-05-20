using PA.Server.Db.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Server.Db
{
    public class PaDbContext : DbContext
    {
        public DbSet<PayoutType> PayoutTypes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeStatusHistory> EmployeeStatusHistoryItems { get; set; }
        public DbSet<Payout> Payouts { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}
