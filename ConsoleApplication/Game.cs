using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public abstract class Game
    {
        public abstract void StartGame();
        public abstract void PauseGame();
        public abstract void StopGame();
    }

    class GameLife : Game
    {
        private readonly GenerationalFill _fillGeneration;
        private readonly GenerationalPrint _printResult;
        private Generation _currentGeneration;
        private readonly ConsoleStyle _consoleStyle;

        public GameLife(int dimensionX, int dimensionY, int increase)
        {
            _fillGeneration = new GenerationalFill();
            _printResult = new GenerationalPrint();
            _currentGeneration = new Generation();
            _currentGeneration.DimensionX = dimensionX;
            _currentGeneration.DimensionY = dimensionY;
            _currentGeneration.Increase = increase;
            _consoleStyle = new ConsoleStyle();

        }

        public override void StartGame()
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

        public override void PauseGame() { }

        public override void StopGame() { }
    }
}
