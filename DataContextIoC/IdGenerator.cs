using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContextIoC
{
    public interface IIdGenerator
    {
        int NextId();
    }

    public class IdGenerator : IIdGenerator
    {
        private int _currentId;

        public IdGenerator(int start)
        {
            this._currentId = start;
        }

        public int NextId()
        {
            ++_currentId;
            return _currentId;
        }
    }
}
