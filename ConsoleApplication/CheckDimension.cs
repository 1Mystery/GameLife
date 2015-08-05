using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class CheckDimension
    {
        public int CheckFieldColumns(Generation nextGeneration, int column, int step)
        {
            for (int j = column; j <= nextGeneration.DimensionY && j >= 0; j += step)
            {
                for (int i = 0; i < nextGeneration.DimensionX; i++)
                {
                    if (nextGeneration.ReadValueXY(i, j) == 1) return j;
                }
            }
            return -1;
        }

        public int CheckFieldRows(Generation nextGeneration, int row, int step)
        {
            for (int i = row; i <= nextGeneration.DimensionX && i >= 0; i += step)
            {
                for (int j = 0; j < nextGeneration.DimensionY; j++)
                {
                    if (nextGeneration.ReadValueXY(i, j) == 1) return i;
                }
            }
            return -1;
        }
    }
}

