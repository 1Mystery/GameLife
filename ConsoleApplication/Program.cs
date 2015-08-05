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
                Console.WriteLine("1. Start game with limited field");
                Console.WriteLine("2. Start game with unlimited field");
                Console.WriteLine("");
                Console.Write("Please type variant: ");
                int variant = int.Parse(Console.ReadLine());
                Context context = new Context();
                switch (variant)
                {
                    case 1: 
                        context.SetStrategy(new StrategyOfLimitedField(50, 100)); context.ExecuteOperation(); break;
                    case 2:
                        Console.Clear();
                        Console.Write("Please enter dimension X: ");
                        int dimensionX = int.Parse(Console.ReadLine());
                        Console.Write("Please enter dimension Y: ");
                        int dimensionY = int.Parse(Console.ReadLine());
                        context.SetStrategy(new StrategyOfUnlimitedField(dimensionY, dimensionX)); context.ExecuteOperation(); break;
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



            /*try
            {
                Console.WriteLine("1. Start game with limited field (with default dimension 50x100)");
                Console.WriteLine("1.1 Start game with limited field (with ability to set dimension)");
                Console.WriteLine("2. Start game with unlimited field");
                Console.WriteLine("");
                Console.Write("Please select one of the variants (1, 2 or 3 are allowed): ");
                int variant = int.Parse(Console.ReadLine());
                Context context = new Context();
                switch (variant)
                {
                    case 1:
                        context.SetStrategy(new StrategyOfLimitedField(50, 100));
                        context.ExecuteOperation();
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Please enter dimension X: ");
                        int dimensionX = int.Parse(Console.ReadLine());
                        Console.Write("Please enter dimension Y: ");
                        int dimensionY = int.Parse(Console.ReadLine());
                        context.SetStrategy(new StrategyOfLimitedField(dimensionY, dimensionX));
                        context.ExecuteOperation();
                        break;
                    case 3:
                        context.SetStrategy(new StrategyOfUnlimitedField());
                        context.ExecuteOperation();
                        break;
                    default:
                        Console.WriteLine("Please choose case 1, 2 or 3");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Console.ReadLine();
            }  */

        }
    }
}
