using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Core.Models
{
    [Serializable]
    public class PayoutModel
    {
        public int Id { get; set; }
        public double Sum { get; set; }
        public string PayoutType { get; set; }
    }
}
