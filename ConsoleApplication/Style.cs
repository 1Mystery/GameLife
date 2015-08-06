using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Style
    {
        public void ApplyConsoleStyle()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
        }
    }
}
