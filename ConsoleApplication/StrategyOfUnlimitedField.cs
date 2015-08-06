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
        private readonly GameLife _game;
        public StrategyOfUnlimitedField(int dimensionX, int dimensionY, int increase)
        {
            _game = new GameLife(dimensionX, dimensionY, increase);
        }

        public void Algorithm()
        {
            Console.WriteLine("Starting algorithm for strategy 1.");
            Thread.Sleep(3000);
            Console.Clear();
            _game.StartGame();
        }
    }
}
