using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Core.Models
{
    [Serializable]
    public class AssignPayoutModel
    {
        public int PayoutTypeId { get; set; }
        public double Sum { get; set; }
        public int EmployeeId { get; set; }
    }
}
