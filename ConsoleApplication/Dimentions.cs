using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Dimention
    {
        public Dimention(int dimentionX, int dimentionY)
        {
            this.RowStart = 0;
            this.RowEnd = dimentionX - 1;
            this.ColumnStart = 0;
            this.ColumnEnd = dimentionY - 1;
        }
        public int RowStart { get; set; }
        public int RowEnd { get; set; }
        public int ColumnStart { get; set; }
        public int ColumnEnd { get; set; }
    }
}
