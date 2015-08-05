using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class FieldValidation
    {
        private int dimensionX, dimensionY;

        public FieldValidation(int _dimensionX, int _dimensionY)
        {
            dimensionX = _dimensionX;
            dimensionY = _dimensionY;
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
    }
}
