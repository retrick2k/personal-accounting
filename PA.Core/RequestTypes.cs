using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Core
{
    public enum RequestTypes
    {
        GetEmps,
        CreateEmp,
        EditEmp,
        FireEmp,

        GetDepartments,
        GetDeps,
        CreateDep,
        RemoveDep,
        EditDepartment,

        GetPositions,
        EditPosition,
        CreatePosition,
        RemovePosition,

        CreatePayout,
        EditPayout,
        RemovePayout,
        GetPayouts,

        GetPayoutTypes,
        CreatePayoutType,
        EditPayoutType,
        RemovePayoutType
    }
}
