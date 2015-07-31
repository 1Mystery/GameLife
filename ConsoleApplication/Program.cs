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
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("1. Start game with limited field (with default dimension 50x100)");
                Console.WriteLine("1.1 Start game with limited field (with ability to set dimension)");
                Console.WriteLine("2. Start game with unlimited field");
                Console.Write("Please select one of the variants (1 or 2 are allowed): ");
                int variant = int.Parse(Console.ReadLine());
                Context context = new Context();
                if (variant == 1)
                {
                    context.SetStrategy(new StrategyOfLimitedField(50, 100));
                    context.ExecuteOperation();
                }
                else if (variant == 2)
                {
                    context.SetStrategy(new StrategyOfUnlimitedField());
                    context.ExecuteOperation();
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
