using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Server.Db.Entities
{
    /// <summary>
    /// Выплата (зп, премия и прочие приятные бонусы)
    /// Антибонусы в виде отрицательных выплат тоже могут быть
    /// </summary>
    public class Payout
    {
        public int Id { get; set; }
        public int PayoutTypeId { get; set; }
        public double Sum { get; set; }
        public int EmployeeId { get; set; }
    }
}
