using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class Life
    {
        private int dimensionX, dimensionY;

        public Life(int _dimensionX, int _dimensionY)
        {
            dimensionX = _dimensionX;
            dimensionY = _dimensionY;
            StartGame();
        }

        private cellsArray[,] ProcessGenerations(cellsArray[,] cells)
        {
            int neighbours = 0;

            for (int i = 0; i < dimensionX; i++)
            {
                for (int j = 0; j < dimensionY; j++)
                {
                    cells[i, j].nextGeneration = 0;
                }
            }

            for (int row = 0; row < dimensionX; row++)
            {
                for (int column = 0; column < dimensionY; column++)
                {
                    neighbours = 0;

                    if (row > 0 && column > 0)
                        if (cells[row - 1, column - 1].currentGeneration > 0)
                            neighbours++;

                    if (row > 0)
                        if (cells[row - 1, column].currentGeneration > 0)
                            neighbours++;

                    if (row > 0 && column < dimensionY - 1)
                        if (cells[row - 1, column + 1].currentGeneration > 0)
                            neighbours++;

                    if (column < dimensionY - 1)
                        if (cells[row, column + 1].currentGeneration > 0)
                            neighbours++;

                    if (row < dimensionX - 1 && column < dimensionY - 1)
                        if (cells[row + 1, column + 1].currentGeneration > 0)
                            neighbours++;

                    if (row < dimensionX - 1)
                        if (cells[row + 1, column].currentGeneration > 0)
                            neighbours++;

                    if (row < dimensionX - 1 && column > 0)
                        if (cells[row + 1, column - 1].currentGeneration > 0)
                            neighbours++;

                    if (column > 0)
                        if (cells[row, column - 1].currentGeneration > 0)
                            neighbours++;

                    if (neighbours < 2)
                        cells[row, column].nextGeneration = 0;
                    if (neighbours > 3)
                        cells[row, column].nextGeneration = 0;
                    if ((neighbours == 2 || neighbours == 3) && cells[row, column].currentGeneration > 0)
                        cells[row, column].nextGeneration = 1;
                    if (neighbours == 3)
                        cells[row, column].nextGeneration = 1;
                }
            }

            for (int i = 0; i < dimensionX; i++)
            {
                for (int j = 0; j < dimensionY; j++)
                {
                    cells[i, j].currentGeneration = cells[i, j].nextGeneration;
                }
            }
            return cells;
        }


        private void PrintCells(cellsArray[,] cells)
        {
            for (int row = 0; row < dimensionX; row++)
            {
                for (int column = 0; column < dimensionY; column++)
                {
                    if (cells[row, column].currentGeneration != 0)
                    {
                        cells[row, column].currentGeneration = '*';
                        Console.Write((char)cells[row, column].currentGeneration);
                    }
                    else { Console.Write(" "); }
                }
                Console.WriteLine();
            }
        }

        private void MakeRandomDistribution(cellsArray[,] cells)
        {
            Random random = new Random();
            for (int row = 0; row < dimensionX; row++)
            {
                for (int column = 0; column < dimensionY; column++)
                {
                    cells[row, column].currentGeneration = random.Next(0, 2);
                }
            }
        }

        private void StartGame()
        {
            cellsArray[,] cells = new cellsArray[dimensionX, dimensionY];
            MakeRandomDistribution(cells);
            PrintCells(cells);

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = (ConsoleColor.Black);
            while (true)
            {
                ProcessGenerations(cells);
                Console.SetCursorPosition(0, 0);
                PrintCells(cells);
                Thread.Sleep(1000);
            }
        }

        private struct cellsArray
        {
            public int currentGeneration;
            public int nextGeneration;
        }
    }
}