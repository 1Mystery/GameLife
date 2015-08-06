using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public abstract class Style
    {
        public abstract void ApplyStyle(Generation currentGeneration);
    }

    class ConsoleStyle : Style
    {
        public override void ApplyStyle()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
        }
    }
}
