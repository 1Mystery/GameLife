using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public interface IPrint
    {
        void PrintField(Generation currentGeneration);
        void PrintResult(Generation currentGeneration);
    }

    class GenerationalPrint : IPrint
    {

        public void PrintField(Generation currentGeneration) { }

        public void PrintResult(Generation currentGeneration)
        {
            for (int row = 0; row < currentGeneration.DimensionX; row++)
            {
                for (int column = 0; column < currentGeneration.DimensionY; column++)
                {
                    if (currentGeneration.ReadValueXY(row, column) != 0)
                    {
                        currentGeneration.WriteValueXY(row, column, 1);
                        Console.Write((char)currentGeneration.ReadValueXY(row, column));
                    }
                    else { Console.Write(" "); }
                }
                Console.WriteLine();
            }
        }

        public void PrintGameOver()
        {
            Console.WriteLine("Game Over!");
        }

    }
}
