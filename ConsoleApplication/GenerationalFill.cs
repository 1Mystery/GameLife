using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class GenerationalFill
    {
        private GenerationalChange _makeChange;

        public GenerationalFill()
        {
            _makeChange = new GenerationalChange();
        }
        public void MakeRandomFilling(Generation currentGeneration)
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
            nextGeneration.DimensionX = currentGeneration.DimensionX + 2;
            nextGeneration.DimensionY = currentGeneration.DimensionY + 2;

            for (int row = 0; row < nextGeneration.DimensionX; row++)
            {
                Region listRow = new Region();
                for (int column = 0; column < nextGeneration.DimensionY; column++)
                {
                    CheckForModification check = new CheckForModification(currentGeneration, row - 1, column - 1);
                    listRow.Add(check.CheckStatusForNeighbours());
                    check.Dispose();
                }
                nextGeneration.WriteRow(listRow);
            }

            return _makeChange.RewriteGeneration(currentGeneration, nextGeneration);
        }
    }
}
