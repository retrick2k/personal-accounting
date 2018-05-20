using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Core.Models
{
    [Serializable]
    public class EditPayoutModel
    {
        public int PayoutId { get; set; }
        public double Sum { get; set; }
    }
}
