using System.Collections.Generic;

namespace TodoApplication
{
    public class ListModel<TItem>
    {
        public List<TItem> Items { get; }
        private readonly LimitedSizeStack<(bool isAdded, int number, TItem item)> _tupleStack;

        public ListModel(int limit)
        {
            Items = new List<TItem>();
            _tupleStack = new LimitedSizeStack<(bool, int, TItem)>(limit);
        }

        public void AddItem(TItem item)
        {
            Items.Add(item);
            var tuple = (true, Items.Count - 1, item);
            _tupleStack.Push(tuple);
        }

        public void RemoveItem(int index)
        {
            var tuple = (false, index, Items[index]);
            _tupleStack.Push(tuple);
            Items.RemoveAt(index);
        }

        public bool CanUndo()
        {
            return _tupleStack.Count > 0;
        }

        public void Undo()
        {
            if (!CanUndo()) return;
            var tuple = _tupleStack.Pop();
            if (tuple.isAdded)
                Items.RemoveAt(tuple.number);
            else 
                Items.Insert(tuple.number, tuple.item);
        }
    }
}