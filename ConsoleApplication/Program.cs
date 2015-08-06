using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        private static ProgramContext _context;

        static void Main(string[] args)
        {
            try
            {
                Console.Write("Please enter dimension X: "); int dimensionX = int.Parse(Console.ReadLine());
                Console.Write("Please enter dimension Y: "); int dimensionY = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("1. Start game with limited field");
                Console.WriteLine("2. Start game with unlimited field");
                Console.WriteLine("");
                Console.Write("Please type variant: ");
                int variant = int.Parse(Console.ReadLine());
                _context = new ProgramContext();
                Console.Clear();
                switch (variant)
                {
                    case 1:
                        _context.SetStrategy(new StrategyOfLimitedField(dimensionY, dimensionX, 0)); _context.ExecuteOperation(); break;
                    case 2:
                        _context.SetStrategy(new StrategyOfUnlimitedField(dimensionY, dimensionX, 1)); _context.ExecuteOperation(); break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
