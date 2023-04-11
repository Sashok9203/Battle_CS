using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_CS
{
    internal static class Output
    {
        public static void Write(string text ,int x, int y, ConsoleColor color)
        {
            ConsoleColor def = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x,y);
            Console.Write(text);
            Console.ForegroundColor = def;
        }
        public static void Write(string text, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }
        public static void Write(string text, ConsoleColor color)
        {
            ConsoleColor def = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = def;
        }

        public static void WriteLine(string text, int x, int y, ConsoleColor color)
        {
            Write(text + '\n', x, y, color);
        }

        public static void WriteLine(string text, int x, int y)
        {
            Write(text + '\n', x, y);
        }

        public static void WriteLine(string text, ConsoleColor color)
        {
            Write(text + '\n', color);
        }
        public static void ClearRegion(int Xpos, int YPos, int XCout, int yCount)
        {
            string tmp = new string(' ', XCout);
            for (int i = 0; i != yCount; i++)
            {
                Console.SetCursorPosition(Xpos, YPos + i);
                Console.Write(tmp);
            }
        }
    }
}
