using System.Collections;
using System.Linq.Expressions;

namespace Battle_CS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Battle battle = new Battle("Army1", "Army2", 6);
                battle.Start(500);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}