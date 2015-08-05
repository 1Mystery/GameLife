using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class StrategyOfLimitedField : IStrategy
    {
        private int dimensionX, dimensionY;

        public StrategyOfLimitedField(int _dimensionX, int _dimensionY)
        {
            dimensionX = _dimensionX;
            dimensionY = _dimensionY;
        }

        public void Algorithm()
        {
            Console.WriteLine("Starting algorithm for strategy 1.");
            Thread.Sleep(3000);
            Console.Clear();
            StartGame();
        }

        private Array ProcessGeneration(int[,] currentGeneration)
        {
            int[,] nextGeneration = new int[dimensionX, dimensionY];
            int neighbours = 0;

            for (int row = 0; row < dimensionX; row++)
            {
                for (int column = 0; column < dimensionY; column++)
                {
                    neighbours = IsNeighbour(currentGeneration, row - 1, column - 1) +
                        IsNeighbour(currentGeneration, row - 1, column) +
                        IsNeighbour(currentGeneration, row - 1, column + 1) +
                        IsNeighbour(currentGeneration, row, column + 1) +
                        IsNeighbour(currentGeneration, row + 1, column + 1) +
                        IsNeighbour(currentGeneration, row + 1, column) +
                        IsNeighbour(currentGeneration, row + 1, column - 1) +
                        IsNeighbour(currentGeneration, row, column - 1);

                    if (neighbours < 2)
                        nextGeneration[row, column] = 0;
                    if (neighbours > 3)
                        nextGeneration[row, column] = 0;
                    if ((neighbours == 2 || neighbours == 3) && currentGeneration[row, column] > 0)
                        nextGeneration[row, column] = 1;
                    if (neighbours == 3)
                        nextGeneration[row, column] = 1;
                }
            }

            for (int i = 0; i < dimensionX; i++)
            {
                for (int j = 0; j < dimensionY; j++)
                {
                    currentGeneration[i, j] = nextGeneration[i, j];
                }
            }
            return currentGeneration;
        }

        private int IsNeighbour(int[,] currentGeneration, int row, int column)
        {
            if (row >= 0 && row < dimensionX && column >= 0 && column < dimensionY)
                if (currentGeneration[row, column] > 0)
                    return 1;
            return 0;
        }

        private void PrintCells(int[,] currentGeneration)
        {
            for (int row = 0; row < dimensionX; row++)
            {
                for (int column = 0; column < dimensionY; column++)
                {
                    if (currentGeneration[row, column] != 0)
                    {
                        currentGeneration[row, column] = '*';
                        Console.Write((char)currentGeneration[row, column]);
                    }
                    else { Console.Write(" "); }
                }
                Console.WriteLine();
            }
        }

        private void MakeRandomDistribution(int[,] currentGeneration)
        {
            Random random = new Random();
            for (int row = 0; row < dimensionX; row++)
            {
                for (int column = 0; column < dimensionY; column++)
                {
                    currentGeneration[row, column] = random.Next(0, 2);
                }
            }
        }

        private void StartGame()
        {
            int[,] currentGeneration = new int[dimensionX, dimensionY];
            MakeRandomDistribution(currentGeneration);
            Console.SetCursorPosition(0, 0);
            PrintCells(currentGeneration);

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = (ConsoleColor.Black);
            while (true)
            {
                ProcessGeneration(currentGeneration);
                Console.SetCursorPosition(0, 0);
                PrintCells(currentGeneration);
                Thread.Sleep(1000);
            }
        }
    }
}
