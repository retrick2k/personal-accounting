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
        public virtual DbSet<PayoutType> PayoutTypes { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeStatusHistory> EmployeeStatusHistoryItems { get; set; }
        public virtual DbSet<Payout> Payouts { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
    }
}
