using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Server.Db.Entities
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public virtual Position Position { get; set; }
        public int PositionId { get; set; }
        public int DepartmentId { get; set; }
    }
}
