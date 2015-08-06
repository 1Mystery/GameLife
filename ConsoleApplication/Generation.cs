using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class Generation
    {
        private List<Region> _data;
        public Generation()
        {
            _data = new List<Region>();
            this.Increase = 0;
        }

        public int ReadValueXY(int x, int y)
        {
            return _data[x][y];
        }

        public void WriteValueXY(int x, int y, int value)
        {
            _data[x][y] = value;
        }

        public void WriteRow(Region row)
        {
            _data.Add(row);
        }

        public void ClearContent()
        {
            _data.Clear();
        }

        public int Count()
        {
            return _data.Count();
        }

        public int DimensionX { get; set; }

        public int DimensionY { get; set; }

        public int Increase { get; set; }
    }
}
