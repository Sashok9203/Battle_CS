using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_CS
{
    internal class Battle
    {
        private Army army1;
        private Army army2;
        private uint roundNumber = 0;
        private bool Round(CombatVehicle cv1, CombatVehicle cv2, uint timeDelay)
        {
           
            Output.ClearRegion(4, 7 + army2.Count, 30, 6);
            cv1.ShowInfo(4, 7 + army1.Count, ConsoleColor.DarkYellow);
            bool attack = false;
            do
            {
                Output.ClearRegion(attack ? 4 : 35, 7 + army2.Count, 30, 6);
                if (!attack)
                {
                    cv2.Defense(cv1.Attack());
                    cv2.ShowInfo(35, 7 + army2.Count, ConsoleColor.Blue);
                }
                else 
                {
                    cv1.Defense(cv2.Attack());
                    cv1.ShowInfo(4, 7 + army1.Count, ConsoleColor.DarkYellow);
                }
                if (timeDelay != 0) Thread.Sleep((int)timeDelay);
                else Console.ReadKey(false);
                attack = !attack;
            } while (!cv1.IsDestroyed() && !cv2.IsDestroyed()) ;
            return cv2.IsDestroyed();
        }


        public Battle(string armyName,string armyName2,uint troopersCount)
        {
            Console.CursorVisible = false ;
            CombatVehicleCreator cvc = new CombatVehicleCreator();
            army1 = new Army(armyName, troopersCount, cvc);
            army2 = new Army(armyName2, troopersCount, cvc);
        }

        public bool Start(uint timeDelay = 1000) 
        {
            CombatVehicle? cv1 = null,cv2 = null;
            Output.WriteLine($"-= Battle =-",23,0, ConsoleColor.Green);
            Console.Write("\t\t -= \"");
            Output.Write(army1.Name,Console.GetCursorPosition().Left, Console.GetCursorPosition().Top, ConsoleColor.DarkYellow);
            Console.Write("\"  vs  \"");
            Output.Write(army2.Name, Console.GetCursorPosition().Left, Console.GetCursorPosition().Top, ConsoleColor.Blue);
            Console.WriteLine("\"=-");
            army1.Show(4,3,ConsoleColor.DarkYellow);
            army2.Show(35,3,ConsoleColor.Blue);

            while (army1.GetTrooper(out cv1) && army2.GetTrooper(out cv2))
            {
                ++roundNumber;
                Output.WriteLine($" --------- Round {roundNumber,2} ---------", 15, 5 + army2.Count, ConsoleColor.Yellow);
                Round(cv1, cv2, timeDelay);
                army1.Show(4, 3, ConsoleColor.DarkYellow);
                army2.Show(35, 3, ConsoleColor.Blue);
            }
            if (cv2 == null) Output.Write($"{army1.Name}" , 17, 14 + army2.Count);
            else Output.Write($"{army2.Name}", 17, 14 + army2.Count);
            Console.WriteLine($" win at {roundNumber} round !!! ");
            return  cv2 == null;
        }

    }
}
