using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class StrategyOfUnlimitedField : IStrategy
    {
        private readonly GenerationalFill _fillGeneration;
        private readonly PrintResult _printResult;
        private Generation _currentGeneration;

        public StrategyOfUnlimitedField(int dimensionX, int dimensionY)
        {
            _fillGeneration = new GenerationalFill();
            _printResult = new PrintResult();
            _currentGeneration = new Generation();
            _currentGeneration.DimensionX = dimensionX;
            _currentGeneration.DimensionY = dimensionY;
        }

        public void Algorithm()
        {
            Console.WriteLine("Starting algorithm for strategy 2.");
            Thread.Sleep(3000);
            Console.Clear();
            StartGame();
        }

        private void StartGame()
        {
            _fillGeneration.MakeRandomFilling(_currentGeneration);
            Console.SetCursorPosition(0, 0);

            _printResult.PrintResultToConsole(_currentGeneration);

            while (_currentGeneration.Count() > 0)
            {
                _fillGeneration.RefillGeneration(_currentGeneration);
                Console.SetCursorPosition(0, 0);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.ForegroundColor = (ConsoleColor.Black);
                Console.BackgroundColor = ConsoleColor.White;
                _printResult.PrintResultToConsole(_currentGeneration);
                Thread.Sleep(1000);
            }
        }
    }

}
