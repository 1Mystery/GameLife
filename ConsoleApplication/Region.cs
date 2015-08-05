using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Region : List<int>
    {
        private List<int> _dataRow;
        public Region()
        {
            _dataRow = new List<int>();
        }

        /*public List<int> ReadValue()
        {
            return _dataRow;
        } */

        /*public void WriteValue(int valueXY)
        {
            _dataRow.Add(valueXY);
        }*/
    }
}
