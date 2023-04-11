using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Battle_CS
{
    internal class Army 
    {
        private int tIndex = 0;
        private CombatVehicle[] troops;
        public string Name { get; init; }
        public int Count => troops.Length;
        public Army(string? name, uint count, IVehicleCreate vc)
        {
            Random rnd = new Random();
            if (String.IsNullOrWhiteSpace(name)) throw new ApplicationException($"Name does not be empty");
            if (count < 5 || count > 10) throw new ApplicationException($"Invalid vechicle count value {count}...must be 5 - 10");
            troops = new CombatVehicle[count];
            Name = name;
            for (int i = 0; i < troops.Length; i++)
                troops[i] = vc.GetCombatVehical((CombatVehicleType)rnd.Next(0, Enum.GetValues(typeof(CombatVehicleType)).Length));
        }
        public void Show(int X,int Y,ConsoleColor color)
        {
            Output.WriteLine($"      ---- {Name} ----",X,Y,color);
            for (int i = 0;i < troops.Length;i++) 
                Output.WriteLine($"{(i+1 + ":"),-3} {troops[i]}", X, Y + i + 1,(troops[i].Health <= 0? ConsoleColor.Red:color));
        }
        public bool GetTrooper(out CombatVehicle? cv)
        {
            if(troops[tIndex].Health <= 0) ++tIndex;
            if (tIndex < troops.Length) cv =  troops[tIndex];
            else cv = null;
            return cv != null;
        }
        
    }
}
