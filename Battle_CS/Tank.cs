using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_CS
{
    internal sealed class Tank : CombatVehicle
    {
        readonly double  rechTime, accuracy, armor;
        public Tank(string? name, double health, double recTime, double shAccur, double arm) : base(name, CombatVehicleType.Tank, health)
        {
            if (recTime <= 0 || shAccur <= 0 || arm <= 0) throw new ApplicationException(" Invalid Tank value...");
            rechTime = recTime;
            accuracy = shAccur;
            armor = arm;
        }
        public override double Attack() => IsDestroyed() ? 0 : 100 * accuracy / rechTime;
        public override void Defense(double damage) => Health -= (damage - armor);
        public override void ShowInfo(int X, int Y, ConsoleColor color)
        {
            base.ShowInfo(X,  Y, color);
            ConsoleColor def = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Output.WriteLine($"  RechTime  : {rechTime:F2}", X, Y + 3);
            Output.WriteLine($"  Accuracy  : {accuracy:F2}", X, Y + 4);
            Output.WriteLine($"  Armor     : {armor:F2}", X, Y + 5);
            Console.ForegroundColor = def;
        }
    }
}
