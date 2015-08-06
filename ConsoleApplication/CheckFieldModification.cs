using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class CheckFieldModification : IDisposable
    {

        private Generation _currentGeneration;
        private int _row, _column;
        bool disposed = false;

        public CheckFieldModification(Generation currentGeneration, int row, int column)
        {
            _currentGeneration = currentGeneration;
            _row = row;
            _column = column;
        }

        public int CheckStatusForNeighbours()
        {
            int neighbours = DetermineCountOfNeighbours(_row - 1, _column - 1) + DetermineCountOfNeighbours(_row - 1, _column) + DetermineCountOfNeighbours(_row - 1, _column + 1) +
                DetermineCountOfNeighbours(_row, _column + 1) + DetermineCountOfNeighbours(_row + 1, _column + 1) + DetermineCountOfNeighbours(_row + 1, _column) +
                DetermineCountOfNeighbours(_row + 1, _column - 1) + DetermineCountOfNeighbours(_row, _column - 1);
            return DetermineLiveNeighbour(neighbours);
        }

        private int DetermineCountOfNeighbours(int row, int column)
        {
            if (row >= 0 && row < _currentGeneration.DimensionX && column >= 0 && column < _currentGeneration.DimensionY)
                if (_currentGeneration.ReadValueXY(row, column) > 0)
                    return 1;
            return 0;
        }

        private int DetermineLiveNeighbour(int neighbours)
        {
            if (neighbours < 2) return 0;
            if (neighbours > 3) return 0;
            if (neighbours == 3) return 1;
            if ((neighbours == 2 || neighbours == 3) && _row >= 0 && _column >= 0 && _row < _currentGeneration.DimensionX && _column < _currentGeneration.DimensionY)
                if (_currentGeneration.ReadValueXY(_row, _column) > 0)
                    return 1;
            return 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            disposed = true;
        }

    }
}
