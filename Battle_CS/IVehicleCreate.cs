using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_CS
{
    internal interface IVehicleCreate
    {
        CombatVehicle GetCombatVehical(CombatVehicleType type);
    }
}
