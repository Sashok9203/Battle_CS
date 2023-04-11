using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_CS
{
    internal sealed class Tank : CombatVehicle
    {
        double R, A, T;
        public Tank(string? name, double health, double recTime, double shAccur, double arm) : base(name, CombatVehicleType.Tank, health)
        {
            R = recTime;
            A = shAccur;
            T = arm;
        }
        public override double Attack() => IsDestroyed() ? 0 : 100 * A / R;
        public override void Defense(double damage) => Health -= (damage - T);
        public override void ShowInfo(int X, int Y, ConsoleColor color)
        {
            base.ShowInfo(X,  Y, color);
            ConsoleColor def = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Output.WriteLine($"  RechTime  : {R:F2}", X, Y + 3);
            Output.WriteLine($"  Accuracy  : {A:F2}", X, Y + 4);
            Output.WriteLine($"  Armor     : {T:F2}", X, Y + 5);
            Console.ForegroundColor = def;
        }
    }
}
