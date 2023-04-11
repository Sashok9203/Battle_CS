using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_CS
{
    internal sealed class ArmoredCar : CombatVehicle
    {
        double C, S;
        public ArmoredCar(string? name, double health, double wepCount, double speed) : base(name, CombatVehicleType.ArmoredCar, health)
        {
            C = wepCount;
            S = speed;
        }
        public override double Attack() => IsDestroyed() ? 0 : 50 * C;
        public override void Defense(double damage) => Health -= (damage - S/2);
        public override void ShowInfo(int X, int Y, ConsoleColor color)
        {
            base.ShowInfo(X, Y, color);
            ConsoleColor def = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Output.WriteLine($"  WepCount  : {C:F2}", X, Y + 3);
            Output.WriteLine($"  Speed     : {S:F2}", X, Y + 4);
            Console.ForegroundColor = def;
        }
    }
}
