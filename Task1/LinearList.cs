using System.Collections.Generic;

namespace Task1
{
    public class LinearList<T>
    {
        private readonly List<T> _items = new List<T>();
        private int _currentIndex = -1;
        
        public T? CurrentItem => IsEmpty ? default : _items[_currentIndex];
        
        public int Count => _items.Count;

        public bool IsEmpty => Count == 0;
        
        public void Add(T item)
        {
            _items.Add(item);
            if (_currentIndex == -1)
            {
                _currentIndex = 0;
            }
        }
        
        public bool RemoveCurrent()
        {
            if (IsEmpty)
            {
                return false;
            }

            _items.RemoveAt(_currentIndex);
            
            if (_currentIndex >= Count)
            {
                _currentIndex = Count - 1;
            }
            
            if (IsEmpty)
            {
                _currentIndex = -1;
            }
            
            return true;
        }
        
        public bool MoveNext()
        {
            if (IsEmpty || _currentIndex >= Count - 1)
            {
                return false;
            }

            _currentIndex++;
            return true;
        }

        public void MoveToStart()
        {
            if (!IsEmpty)
            {
                _currentIndex = 0;
            }
        }
    }
}