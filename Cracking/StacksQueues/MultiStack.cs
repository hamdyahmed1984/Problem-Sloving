using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.StacksQueues
{
    class MultiStack
    {
        /* Stackinfo is a simple class that holds a set of data about each stack. It
         * does not hold the actual items in the stack. We could have done this with
         * just a bunch of individual variables, but that's messy and doesn't gain us
         * much. */
        class StackInfo
        {
            public int Start;
            public int Size;
            public int Capacity;
            public StackInfo(int start, int capacity)
            {
                this.Start = start;
                this.Capacity = capacity;
            }            
            public bool IsEmpty()
            {
                return Size == 0;
            }
            public bool IsFull()
            {
                return Size == Capacity;
            }           
        }

        int?[] values;
        StackInfo[] allStacks;

        public MultiStack(int stacksCount, int initialCapacity)
        {
            allStacks = new StackInfo[stacksCount];
            for (int i = 0; i < stacksCount; i++)
                allStacks[i] = new StackInfo(i * initialCapacity, initialCapacity);
            values = new int?[stacksCount * initialCapacity];
        }
        /* Push value onto stack num, shifting/expanding stacks as necessary. Throws
        * exception if all stacks are full. */
        public void Push(int stackIndex, int data)
        {
            if (AllStacksFull())
                throw new InvalidOperationException("All stacks are full.");
            StackInfo stack = allStacks[stackIndex];
            /* If this stack is full, expand it. */
            if (stack.IsFull())
            {
                Expand(stackIndex);
            }
            /* Find the index of the top element in the array +1, and increment the
            * stack pointer*/
            stack.Size++;
            values[LastElementIndex(stackIndex) ] = data;            
        }

        public int Pop(int stackIndex)
        {
            StackInfo stack = allStacks[stackIndex];
            if (stack.IsEmpty())
                throw new InvalidOperationException("Stack is empty.");
            /* Remove last element. */
            int? data = values[LastElementIndex(stackIndex)];
            values[LastElementIndex(stackIndex)] = null;
            stack.Size--;
            return data.Value;
        }

        public int Peek(int stackIndex)
        {
            StackInfo stack = allStacks[stackIndex];
            if (stack.IsEmpty())
                throw new InvalidOperationException("Stack is empty.");
            return values[LastElementIndex(stackIndex)].Value;
        }
        void Expand(int stackIndex)
        {
            Shift((stackIndex + 1) % allStacks.Length);
            allStacks[stackIndex].Capacity++;
        }
        /* Shift items in stack over by one element. If we have available capacity, then
        * we'll end up shrinking the stack by one element. If we don't have available
        * capacity, then we'll need to shift the next stack over too. */
        private void Shift(int stackIndex)
        {
            StackInfo stack = allStacks[stackIndex];
            /* If this stack is at its full capacity, then you need to move the next
            * stack over by one element. This stack can now claim the freed index. */
            if (stack.IsFull())
            {
                Shift((stackIndex + 1) % allStacks.Length);
                stack.Capacity++;
            }

            int index = LastCapacityIndex(stackIndex);
            while(IsIndexWithinStackCapacity(index, stackIndex))
            {
                int prevIndex = PrevIndex(index);
                values[index] = values[prevIndex];
                index = prevIndex;
            }

            values[stack.Start] = null;
            stack.Start = NextIndex(stack.Start);
            stack.Capacity--;
        }
        /* Adjust index to be within the range of 0 -> length - 1. */
        int AdjustIndex(int index)
        {
            /* Java's mod operator can return neg values. For example, (-11 % 5) will
             * return -1, not 4.We actually want the value to be 4(since we're wrapping
            * around the index). */
            return ((index % values.Length) + values.Length) % values.Length;
        }
        /* Get index after this index, adjusted for wrap around. */
        int NextIndex(int index)
        {
            return AdjustIndex(index + 1);
        }
        /* Get index before this index, adjusted for wrap around. */
        int PrevIndex(int index)
        {
            return AdjustIndex(index - 1);
        }

        bool AllStacksFull()
        {
            return AllElementsCount() == values.Length;
        }

        int AllElementsCount()
        {
            int size = 0;
            for(int i = 0; i < allStacks.Length; i++)
            {
                size += allStacks[i].Size;
            }
            return size;
        }

        int LastElementIndex(int stackIndex)
        {
            StackInfo stack = allStacks[stackIndex];
            return AdjustIndex(stack.Start + stack.Size - 1);
        }
        int LastCapacityIndex(int stackIndex)
        {
            StackInfo stack = allStacks[stackIndex];
            return AdjustIndex(stack.Start + stack.Capacity - 1);
        }

        /* Check if an index on the full array is within the stack boundaries. 
         * The stack can wrap around to the start of the array. */
        bool IsIndexWithinStackCapacity(int index, int stackIndex)
        {
            /* If outside of bounds of array, return false. */
            if (index < 0 || index >= values.Length)
                return false;
            StackInfo stack = allStacks[stackIndex];
            /* If index wraps around, adjust it. */
            int wrappedIndex = index < stack.Start ? index + values.Length : index;
            return wrappedIndex >= stack.Start && wrappedIndex <= stack.Start + stack.Capacity - 1;
        }
    }
}
