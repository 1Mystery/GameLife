using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class GenerationalChange
    {
        public Generation RewriteGeneration(Generation currentGeneration, Generation nextGeneration, Dimention dimentions)
        {
            currentGeneration.DimensionX = dimentions.RowEnd - dimentions.RowStart + 1;
            currentGeneration.DimensionY = dimentions.ColumnEnd - dimentions.ColumnStart + 1;
            currentGeneration.ClearContent();
            for (int row = 0; row < currentGeneration.DimensionX; row++)
            {
                Region listRow = new Region();
                for (int column = 0; column < currentGeneration.DimensionY; column++)
                {
                    listRow.Add(nextGeneration.ReadValueXY(row + dimentions.RowStart, column + dimentions.ColumnStart));
                }
                currentGeneration.WriteRow(listRow);
            }
            return currentGeneration;
        }
    }
}
