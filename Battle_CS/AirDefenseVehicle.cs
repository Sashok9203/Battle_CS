using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_CS
{
    internal sealed class AirDefenseVehicle:CombatVehicle
    {
        double L, R, M;
        public AirDefenseVehicle(string? name, double health, double range, double rate_fire, double mobility) : base(name, CombatVehicleType.AirDefense, health)
        {
            L = range;
            R = rate_fire;
            if (mobility < 1 || mobility > 10) throw new ApplicationException($" Invalid mobility value {mobility} ... must be 1- 10");
            M = mobility;
        }
        public override double Attack() => IsDestroyed() ? 0 : 150 + L * (R / 10);
        public override void Defense(double damage) => Health -= (damage / M);
        public override void ShowInfo(int X, int Y, ConsoleColor color)
        {
            base.ShowInfo(X, Y, color);
            ConsoleColor def = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Output.WriteLine($"  Range     : {L:F2}", X, Y + 3);
            Output.WriteLine($"  Rate fire : {R:F2}", X, Y + 4);
            Output.WriteLine($"  Mobility  : {M:F2}", X, Y + 5);
            Console.ForegroundColor = def;
        }
        
    }
}
