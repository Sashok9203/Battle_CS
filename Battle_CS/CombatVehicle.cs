using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Battle_CS
{
    enum CombatVehicleType
    {
        Tank,
        ArmoredCar,
        AirDefense
    }
    internal abstract class CombatVehicle
    {
        public CombatVehicleType Type { get; init; }
        public string? Name { get; init; } = string.Empty;
        public double Health { get; protected set; }
        public bool IsDestroyed() => Health <= 0;
        public abstract double Attack();
        public abstract void Defense(double damage);
        public virtual void  ShowInfo(int X ,int Y,ConsoleColor color)
        {
            ConsoleColor def = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Output.WriteLine($"  --= {Type} =--", X, Y);
            Output.WriteLine($"  Name      : {Name}", X, Y + 1);
            Output.WriteLine($"  Health    : {(Health > 0 ? Math.Round(Health,2) : "Destroid")}", X, Y + 2);
            Console.ForegroundColor = def;
        }
        public override string ToString() { return $"{Type,-10} | {Name}";}
        protected CombatVehicle(string?name, CombatVehicleType type ,double health)
        {
            if (String.IsNullOrWhiteSpace(name)) throw new ApplicationException(" Name does not be empty...");
            Name = name ;
            Type = type;
            Health = health ; 
        }
    }
}
