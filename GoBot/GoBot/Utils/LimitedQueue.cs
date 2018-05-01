using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBot.Utils
{
    class LimitedQueue<T> : Queue<T>
    {
        private int _limit;

        public LimitedQueue(int limit)
        {
            _limit = limit;
        }

        public int Limit
        {
            get
            {
                return _limit;
            }
            set
            {
                _limit = value;
            }
        }

        public new void Enqueue(T val)
        {
            base.Enqueue(val);
            while (this.Count > _limit) base.Dequeue();
        }
    }
}
