using System;
using System.Collections.Generic;

namespace HackerrankSolutions.CrackingTheCodeInterview.HeapsAux
{
    class MinHeap
    {
        public List<int> Values { get; }
        private int _size;
        public MinHeap()
        {
            Values = new List<int>();
        }
        private bool _hasParent(int index)
        {
            return index > 0;
        }
        private int _getParentIndex(int index)
        {
            return (int)Math.Floor((index - 1) / 2.0);
        }
        private int _getNextChildIndex(int index)
        {
            bool l = _hasLeftChild(index);
            bool r = _hasRightChild(index);
            if (l && r)
            {
                int lIdx = _getLeftChildIndex(index);
                int rIdx = _getRightChildIndex(index);
                // for MinHeap, return the index with the smaller value
                return !Comparer(Values[lIdx], Values[rIdx]) ? lIdx : rIdx;
            }
            if (l)
            {
                return _getLeftChildIndex(index);
            }
            return -1;
        }
        private bool _hasLeftChild(int index)
        {
            return _getLeftChildIndex(index) < _size;
        }
        private int _getLeftChildIndex(int index)
        {
            return 1 + (index * 2);
        }
        private bool _hasRightChild(int index)
        {
            return _getRightChildIndex(index) < _size;
        }
        private int _getRightChildIndex(int index)
        {
            return 2 + (index * 2);
        }
        private void _swap(int index1, int index2)
        {
            int tmpItem = Values[index1];
            Values[index1] = Values[index2];
            Values[index2] = tmpItem;
        }
        protected virtual bool Comparer(int a, int b)
        {
            return a > b;
        }
        private void _heapUp(int index)
        {
            int parentIdx = _getParentIndex(index);
            if (_hasParent(index) && Comparer(Values[parentIdx], Values[index]))
            {
                _swap(parentIdx, index);
                _heapUp(parentIdx);
            }
        }
        private void _heapDown(int index)
        {
            int nextIdx = _getNextChildIndex(index);
            if (nextIdx > -1 && Comparer(Values[index], Values[nextIdx]))
            {
                _swap(nextIdx, index);
                _heapDown(nextIdx);
            }
        }
        public int GetTop()
        {
            if (_size > 0)
            {
                return Values[0];
            }
            return -1;
        }
        public void DeleteTop()
        {
            if (_size > 0)
            {
                int index = _size - 1;
                Values[0] = Values[index];
                Values.RemoveAt(index);
                _size--;
                _heapDown(0);
            }
        }
        public void Add(int v)
        {
            Values.Add(v);
            _size++;
            _heapUp(_size - 1);
        }
    }
}