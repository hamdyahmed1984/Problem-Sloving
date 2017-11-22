using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Graphs
{
    /// <summary>
    /// Heap should be a COMPLETE BINARY tree(all levels are complete except, probably the last level, and all nodes should fill from left to right).
    /// Instead of creating HeapNode we created array to hold the data.
    /// the root node is at index 0. the left child node is as index: (ParentIndex * 2 + 1), the right child node is at index:(ParentIndex * 2 + 2)
    /// and the parent node is at index: ((childIndex - 1) / 2).
    /// 
    /// We created abstract class to hold all common operations of MinHeap and Max Heap
    /// </summary>
    abstract class Heap
    {
        int _capacity;
        protected int _size;
        int[] items;
        public Heap()
        {
            _capacity = 10;
            _size = 0;
            items = new int[_capacity];
        }
        public Heap(int capacity)
        {
            _capacity = capacity;
            _size = 0;
            items = new int[_capacity];
        }

        private void EnsureExtraCapacity()
        {
            if (_size == _capacity)
            {
                _capacity *= 2;
                Array.Resize(ref items, _capacity);
            }
        }
        
        protected int GetLeftChildIndex(int ParentIndex) { return ParentIndex * 2 + 1; }
        protected int GetRightChildIndex(int ParentIndex) { return ParentIndex * 2 + 2; }
        protected int GetParentIndex(int childIndex) { return (childIndex - 1) / 2; }//Also can be calculated: Math.Ceiling((childIndex / 2) - 1)

        protected bool HasLeftChild(int parentIndex) { return GetLeftChildIndex(parentIndex) < _size; }
        protected bool HasRightChild(int parentIndex) { return GetRightChildIndex(parentIndex) < _size; }
        protected bool HasParent(int childIndex) { return GetParentIndex(childIndex) >= 0; }

        /*
         *I think we need to call the HasLeftChild, HasRightChild and HasParent before we call GetLeftChild, GetRightChild and GetParent to avoid exceptions
         * when we we recive index out of range.
         */
        protected int GetLeftChild(int parentIndex) { return items[GetLeftChildIndex(parentIndex)]; }
        protected int GetRightChild(int parentIndex) { return items[GetRightChildIndex(parentIndex)]; }
        protected int GetParent(int childIndex) { return items[GetParentIndex(childIndex)]; }
        protected int GetItem(int index) { return items[index]; }

        public int Size()
        {
            return _size;
        }

        public int Peek()
        {
            if (_size == 0) throw new InvalidOperationException("Heap is empty.");
            return GetItem(0);//Peek returns the min item from the min-heap and max item form the max-heap, which is the root.
        }

        public void Add(int itm)
        {
            EnsureExtraCapacity();
            items[_size] = itm;
            _size++;
            HeapifyUp();
        }

        /// <summary>
        /// Poll means removing the min/max item, the root of the heap
        /// </summary>
        public int Poll()
        {
            int itm = items[0];
            items[0] = items[_size - 1];
            _size--;
            HeapifyDown();
            return itm;
        }

        protected void Swap(int first, int second)
        {
            int tmp = items[first];
            items[first] = items[second];
            items[second] = tmp;
        }

        protected abstract void HeapifyUp();
        protected abstract void HeapifyDown();
    }

    class MinHeap : Heap
    {
        protected override void HeapifyUp()
        {
            int index = _size - 1;
            while (HasParent(index) && GetParent(index) > GetItem(index))
            {
                Swap(index, GetParentIndex(index));
                index = GetParentIndex(index);
            }
        }
        protected override void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))//If there is no left node, there is no right node. this is because the heap should be a complete binary tree(i.e be filled from left to right)
            {
                int smallerChildIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(index) < GetLeftChild(index))
                {
                    smallerChildIndex = GetRightChildIndex(index);
                }
                if (GetItem(index) < GetItem(smallerChildIndex))
                {
                    break;
                }
                else
                {
                    Swap(index, smallerChildIndex);
                }
                index = smallerChildIndex;
            }
        }
    }

    class MaxHeap : Heap
    {
        protected override void HeapifyUp()
        {
            int index = _size - 1;
            while (HasParent(index) && GetParent(index) < GetItem(index))
            {
                Swap(index, GetParentIndex(index));
                index = GetParentIndex(index);
            }
        }
        protected override void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                int smallerChildIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(index) > GetLeftChild(index))
                {
                    smallerChildIndex = GetRightChildIndex(index);
                }
                if (GetItem(index) > GetItem(smallerChildIndex))
                {
                    break;
                }
                else
                {
                    Swap(index, smallerChildIndex);
                }
                index = smallerChildIndex;
            }
        }
    }
}
