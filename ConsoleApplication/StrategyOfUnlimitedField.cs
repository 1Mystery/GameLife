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
        private int dimensionX, dimensionY;

        public StrategyOfUnlimitedField()
        {
            dimensionX = 35;
            dimensionY = 35;
        }

        public void Algorithm()
        {
            Console.WriteLine("Starting algorithm for strategy 2.");
            Thread.Sleep(3000);
            StartGame();
        }

        private List<List<int>> ProcessGeneration(List<List<int>> currentGeneration)
        {
            int[,] nextGeneration = new int[dimensionX + 2, dimensionY + 2];
            int neighbours = 0;

            for (int row = 0; row < dimensionX + 2; row++)
            {
                for (int column = 0; column < dimensionY + 2; column++)
                {
                    //neighbours = CalculateCountOfNeighbours(currentGeneration, row - 1, column - 1);
                    neighbours = IsNeighbour(currentGeneration, row - 2, column - 2) +
                        IsNeighbour(currentGeneration, row - 2, column - 1) +
                        IsNeighbour(currentGeneration, row - 2, column) +
                        IsNeighbour(currentGeneration, row - 1, column) +
                        IsNeighbour(currentGeneration, row, column) +
                        IsNeighbour(currentGeneration, row, column - 1) +
                        IsNeighbour(currentGeneration, row, column - 2) +
                        IsNeighbour(currentGeneration, row - 1, column - 2);

                    if (neighbours < 2)
                        nextGeneration[row, column] = 0;
                    if (neighbours > 3)
                        nextGeneration[row, column] = 0;
                    if ((neighbours == 2 || neighbours == 3) && row > 0 && column > 0 && row <= dimensionX && column <= dimensionY)
                        if (currentGeneration[row - 1][column - 1] > 0)
                            nextGeneration[row, column] = 1;
                    if (neighbours == 3)
                        nextGeneration[row, column] = 1;
                }
            }

            int RowStart, RowEnd, ColumnStart, ColumnEnd;

            RowStart = CheckFieldRows(nextGeneration, 0, 1);
            RowEnd = CheckFieldRows(nextGeneration, dimensionX + 1, -1);
            ColumnStart = CheckFieldColumns(nextGeneration, 0, 1);
            ColumnEnd = CheckFieldColumns(nextGeneration, dimensionY + 1, -1);

            if (RowStart == -1) { currentGeneration.Clear(); dimensionX = 0; dimensionY = 0; return currentGeneration; }

            dimensionX = RowEnd - RowStart + 1;
            dimensionY = ColumnEnd - ColumnStart + 1;

            currentGeneration.Clear();
            for (int i = 0; i < dimensionX; i++)
            {
                List<int> listRow = new List<int>();
                for (int j = 0; j < dimensionY; j++)
                {
                    listRow.Add(nextGeneration[i + RowStart, j + ColumnStart]);
                }
                currentGeneration.Add(listRow);
            }

            return currentGeneration;
        }

        private int CheckFieldColumns(int[,] nextGeneration, int column, int step)
        {
            for (int j = column; j < dimensionY + 2 && j >= 0; j += step)
            {
                for (int i = 0; i < dimensionX + 2; i++)
                {
                    if (nextGeneration[i, j] == 1) return j;
                }
            }
            return -1;
        }

        private int CheckFieldRows(int[,] nextGeneration, int row, int step)
        {
            for (int i = row; i < dimensionX + 2 && i >= 0; i += step)
            {
                for (int j = 0; j < dimensionY + 2; j++)
                {
                    if (nextGeneration[i, j] == 1) return i;
                }
            }
            return -1;
        }

        /*private int CalculateCountOfNeighbours(List<List<int>> currentGeneration, int row, int column)
        {
            int neighbours = 0;
            if (row > 0 && column > 0)
                if (currentGeneration[row - 1][column - 1] > 0)
                    neighbours++;

            if (row > 0 && column >= 0 && column < dimensionY)
                if (currentGeneration[row - 1][column] > 0)
                    neighbours++;

            if (row > 0 && column < dimensionY - 1)
                if (currentGeneration[row - 1][column + 1] > 0)
                    neighbours++;

            if (row >= 0 && row < dimensionX && column < dimensionY - 1)
                if (currentGeneration[row][column + 1] > 0)
                    neighbours++;

            if (row < dimensionX - 1 && column < dimensionY - 1)
                if (currentGeneration[row + 1][column + 1] > 0)
                    neighbours++;

            if (row < dimensionX - 1 && column >= 0 && column < dimensionY)
                if (currentGeneration[row + 1][column] > 0)
                    neighbours++;

            if (row < dimensionX - 1 && column > 0)
                if (currentGeneration[row + 1][column - 1] > 0)
                    neighbours++;

            if (row >= 0 && row < dimensionX && column > 0)
                if (currentGeneration[row][column - 1] > 0)
                    neighbours++;
            return neighbours;
        } */

        private int IsNeighbour(List<List<int>> currentGeneration, int row, int column)
        {
            if (row >= 0 && row < dimensionX && column >= 0 && column < dimensionY)
                if (currentGeneration[row][column] > 0)
                    return 1;
            return 0;
        }

        private void PrintCells(List<List<int>> currentGeneration)
        {
            for (int row = 0; row < dimensionX; row++)
            {
                for (int column = 0; column < dimensionY; column++)
                {
                    if (currentGeneration[row][column] != 0)
                    {
                        currentGeneration[row][column] = '*';
                        Console.Write((char)currentGeneration[row][column]);
                    }
                    else { Console.Write(" "); }
                }
                Console.WriteLine();
            }
        }

        private void MakeRandomDistribution(List<List<int>> currentGeneration)
        {
            Random random = new Random();
            for (int row = 0; row < dimensionX; row++)
            {
                List<int> listRow = new List<int>();
                for (int column = 0; column < dimensionY; column++)
                {
                    listRow.Add(random.Next(0, 2));
                }
                currentGeneration.Add(listRow);
            }
        }

        private void StartGame()
        {
            List<List<int>> currentGeneration = new List<List<int>>();
            MakeRandomDistribution(currentGeneration);
            Console.SetCursorPosition(0, 0);
            PrintCells(currentGeneration);

            while (currentGeneration.Count > 0)
            {
                ProcessGeneration(currentGeneration);
                Console.SetCursorPosition(0, 0);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.ForegroundColor = (ConsoleColor.Black);
                Console.BackgroundColor = ConsoleColor.White;
                PrintCells(currentGeneration);
                Thread.Sleep(1000);

            }
        }

        void ResizeArray<T>(ref T[,] original, int newCoNum, int newRoNum)
        {
            var newArray = new T[newCoNum, newRoNum];
            int columnCount = original.GetLength(1);
            int columnCount2 = newRoNum;
            int columns = original.GetUpperBound(0);
            for (int co = 0; co <= columns; co++)
                Array.Copy(original, co * columnCount, newArray, co * columnCount2, columnCount);
            original = newArray;
        }
    }
}
