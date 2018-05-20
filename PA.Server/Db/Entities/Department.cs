using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Server.Db.Entities
{
    /// <summary>
    /// Отдел
    /// </summary>
    public class Department
    {
        public int Id { get; set; }

        /// <summary>
        /// Расположение отдела
        /// </summary>
        public string Situation { get; set; }

        /// <summary>
        /// Сотрудник-глава отдела
        /// </summary>
        public int EmployeeHeadId { get; set; }

        /// <summary>
        /// Название отдела
        /// </summary>
        public string Name { get; set; }
    }
}
