using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Server.Db.Entities
{
    public class EmployeeStatusHistory
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int EmployeeId { get; set; }
    }
}
