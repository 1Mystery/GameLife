using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public interface IStrategy
    {
        void Algorithm();
    }

    public class Context
    {
        private IStrategy _strategy;

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ExecuteOperation()
        {
            _strategy.Algorithm();
        }
    }
}