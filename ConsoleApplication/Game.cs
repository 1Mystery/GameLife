using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Game
    {
        private readonly GenerationalFill _fillGeneration;
        private readonly GenerationalPrint _printResult;
        private Generation _currentGeneration;
        private readonly ConsoleStyle _consoleStyle;

        public Game(int dimensionX, int dimensionY, int increase)
        {
            _fillGeneration = new GenerationalFill();
            _printResult = new GenerationalPrint();
            _currentGeneration = new Generation();
            _currentGeneration.DimensionX = dimensionX;
            _currentGeneration.DimensionY = dimensionY;
            _currentGeneration.Increase = increase;
            _consoleStyle = new ConsoleStyle();

        }

        public void StartGameLife()
        {
            _fillGeneration.MakeFilling(_currentGeneration);
            _consoleStyle.ApplyStyle();

            while (_currentGeneration.Count() > 0)
            {
                _consoleStyle.ApplyStyle();
                _printResult.PrintResult(_currentGeneration);
                _fillGeneration.RefillGeneration(_currentGeneration);
                Thread.Sleep(1000);
            }
            _consoleStyle.ApplyStyle();
            _printResult.PrintGameOver();
        }
    }
}
