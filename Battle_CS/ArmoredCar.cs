using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_CS
{
    internal sealed class ArmoredCar : CombatVehicle
    {
        double wCount, _speed;
        public ArmoredCar(string? name, double health, double wepCount, double speed) : base(name, CombatVehicleType.ArmoredCar, health)
        {
            if (wepCount <= 0 || speed <= 0 ) throw new ApplicationException(" Invalid Armored Car value...");
            wCount = wepCount;
            _speed = speed;
        }
        public override double Attack() => IsDestroyed() ? 0 : 50 * wCount;
        public override void Defense(double damage) => Health -= (damage - _speed/2);
        public override void ShowInfo(int X, int Y, ConsoleColor color)
        {
            base.ShowInfo(X, Y, color);
            ConsoleColor def = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Output.WriteLine($"  WepCount  : {wCount:F2}", X, Y + 3);
            Output.WriteLine($"  Speed     : {_speed:F2}", X, Y + 4);
            Console.ForegroundColor = def;
        }
    }
}
