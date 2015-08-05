using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class GenerationalChange
    {
        private readonly CheckDimension _checkDimension;
        private int _rowStart, _rowEnd, _columnStart, _columnEnd;

        public GenerationalChange()
        {
            _checkDimension = new CheckDimension();
        }

        public Generation RewriteGeneration(Generation currentGeneration, Generation nextGeneration)
        {
            CheckParams(nextGeneration);
            if (_rowStart == -1) { currentGeneration.ClearContent(); currentGeneration.DimensionX = 0; currentGeneration.DimensionY = 0; return currentGeneration; }
            currentGeneration.DimensionX = _rowEnd - _rowStart + 1;
            currentGeneration.DimensionY = _columnEnd - _columnStart + 1;
            currentGeneration.ClearContent();
            for (int row = 0; row < currentGeneration.DimensionX; row++)
            {
                Region listRow = new Region();
                for (int column = 0; column < currentGeneration.DimensionY; column++)
                {
                    listRow.Add(nextGeneration.ReadValueXY(row + _rowStart, column + _columnStart));
                }
                currentGeneration.WriteRow(listRow);
            }

            return currentGeneration;
        }

        private void CheckParams(Generation nextGeneration)
        {
            _rowStart = _checkDimension.CheckFieldRows(nextGeneration, 0, 1);
            _rowEnd = _checkDimension.CheckFieldRows(nextGeneration, nextGeneration.DimensionX-1, -1);
            _columnStart = _checkDimension.CheckFieldColumns(nextGeneration, 0, 1);
            _columnEnd = _checkDimension.CheckFieldColumns(nextGeneration, nextGeneration.DimensionY-1, -1);
        }
    }
}
