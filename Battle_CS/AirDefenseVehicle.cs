using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_CS
{
    internal sealed class AirDefenseVehicle:CombatVehicle
    {
        double rateFire, fireRange, _mobility;
        public AirDefenseVehicle(string? name, double health, double range, double rate_fire, double mobility) : base(name, CombatVehicleType.AirDefense, health)
        {
            if (range <= 0 || rate_fire <= 0 || mobility <= 0) throw new ApplicationException(" Invalid Air Defense Vehicle value...");
            rateFire = range;
            fireRange = rate_fire;
            if (mobility < 1 || mobility > 10) throw new ApplicationException($" Invalid mobility value {mobility} ... must be 1- 10");
            _mobility = mobility;
        }
        public override double Attack() => IsDestroyed() ? 0 : 150 + rateFire * (fireRange / 10);
        public override void Defense(double damage) => Health -= (damage / _mobility);
        public override void ShowInfo(int X, int Y, ConsoleColor color)
        {
            base.ShowInfo(X, Y, color);
            ConsoleColor def = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Output.WriteLine($"  Range     : {rateFire:F2}", X, Y + 3);
            Output.WriteLine($"  Rate fire : {fireRange:F2}", X, Y + 4);
            Output.WriteLine($"  Mobility  : {_mobility:F2}", X, Y + 5);
            Console.ForegroundColor = def;
        }
        
    }
}
