using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public abstract class FillGeneration
    {
        public abstract void MakeFilling(Generation currentGeneration);
        public abstract void CheckDimentions(Generation nextGeneration);
    }

    class GenerationalFill : FillGeneration
    {
        private GenerationalChange _makeChange;
        private readonly CheckFieldDimensions _checkDimension;
        private Dimentions _dimentions;

        public GenerationalFill()
        {
            _makeChange = new GenerationalChange();
            _checkDimension = new CheckFieldDimensions();

        }
        public override void MakeFilling(Generation currentGeneration)
        {
            Random random = new Random();
            for (int row = 0; row < currentGeneration.DimensionX; row++)
            {
                Region listRow = new Region();
                for (int column = 0; column < currentGeneration.DimensionY; column++)
                {
                    listRow.Add(random.Next(0, 2));
                }
                currentGeneration.WriteRow(listRow);
            }
        }

        public Generation RefillGeneration(Generation currentGeneration)
        {
            Generation nextGeneration = new Generation();
            nextGeneration.DimensionX = currentGeneration.DimensionX + currentGeneration.Increase * 2;
            nextGeneration.DimensionY = currentGeneration.DimensionY + currentGeneration.Increase * 2;

            for (int row = 0; row < nextGeneration.DimensionX; row++)
            {
                Region listRow = new Region();
                for (int column = 0; column < nextGeneration.DimensionY; column++)
                {
                    CheckFieldModification check = new CheckFieldModification(currentGeneration, row - currentGeneration.Increase, column - currentGeneration.Increase);
                    listRow.Add(check.CheckStatusForNeighbours());
                    check.Dispose();
                }
                nextGeneration.WriteRow(listRow);
            }
            if (_checkDimension.CheckFieldRows(nextGeneration, 0, 1) == -1) { currentGeneration.ClearContent(); return currentGeneration; }
            _dimentions = new Dimentions(currentGeneration.DimensionX, currentGeneration.DimensionY);
            if (currentGeneration.Increase > 0) CheckDimentions(nextGeneration);
            return _makeChange.RewriteGeneration(currentGeneration, nextGeneration, _dimentions);
        }

        public override void CheckDimentions(Generation nextGeneration)
        {
            _dimentions.RowStart = _checkDimension.CheckFieldRows(nextGeneration, 0, 1);
            _dimentions.RowEnd = _checkDimension.CheckFieldRows(nextGeneration, nextGeneration.DimensionX - 1, -1);
            _dimentions.ColumnStart = _checkDimension.CheckFieldColumns(nextGeneration, 0, 1);
            _dimentions.ColumnEnd = _checkDimension.CheckFieldColumns(nextGeneration, nextGeneration.DimensionY - 1, -1);
        }
    }
}
