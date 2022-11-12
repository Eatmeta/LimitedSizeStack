using System;
using System.Collections.Generic;

namespace TodoApplication
{
    public class LimitedSizeStack<T>
    {
        private int _limit;
        private readonly LinkedList<T> _linkedListStack = new LinkedList<T>();

        public int Limit
        {
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("History length must be non negative");
                _limit = value;
            }
            get => _limit;
        }

        public LimitedSizeStack(int limit) => _limit = limit;

        public void Push(T item)
        {
            if (_limit == 0)
                return;
            if (_linkedListStack.Count < _limit)
                _linkedListStack.AddLast(item);
            else
            {
                _linkedListStack.RemoveFirst();
                _linkedListStack.AddLast(item);
            }
        }

        public T Pop()
        {
            if (_linkedListStack.Count == 0)
                return (T) new object();

            var last = _linkedListStack.Last;
            _linkedListStack.RemoveLast();
            return last.Value;
        }

        public int Count => _linkedListStack.Count;
    }
}