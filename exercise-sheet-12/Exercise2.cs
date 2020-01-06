using System;

namespace exercise_sheet_12
{
    class Exercise2
    {
        public Exercise2()
        {
            PriorityQueue queue = new PriorityQueue(12);
            queue.Insert(1, 5);
            queue.Insert(1, 3);
            queue.Insert(1, 17);
            queue.Insert(1, 10);
            queue.Insert(1, 84);
            queue.Insert(1, 19);
            queue.Insert(1, 6);
            queue.Insert(1, 22);
            queue.Insert(1, 9);
        
            Console.WriteLine("Extracted: " + queue.ExtractMin());
            queue.Print();

            Console.WriteLine("Extracted: " + queue.ExtractMin());
            queue.Print();

            Console.WriteLine("Extracted: " + queue.ExtractMin());
            queue.Print();

            Console.WriteLine("Extracted: " + queue.ExtractMin());
            queue.Print();

            Console.WriteLine("Extracted: " + queue.ExtractMin());
            queue.Print();

            Console.WriteLine("Extracted: " + queue.ExtractMin());
            queue.Print();
        }
    }

    class PriorityQueue
    {
        MinHeap heap;

        public PriorityQueue(int maxSize)
        {
            this.heap = new MinHeap(maxSize);
        }

        public void Insert(int value, int priority)
        {
            this.heap.Insert(priority);
            this.heap.BuildHeap();
        }

        public int GetMin()
        {
            return this.heap.GetMin();
        }

        public int ExtractMin()
        {
            return this.heap.ExtractMin();
        }

        public void DecreaseKey(int position, int newPriority)
        {
            this.heap.DecreaseKey(position, newPriority);
        }

        public void Print()
        {
            this.heap.Print();
        }
    }

    class MinHeap
    {
        private int[] heap;
        private int size;
        private int maxSize;

        public MinHeap(int maxSize)
        {
            this.maxSize = maxSize;
            this.size = 0;

            this.heap = new int[this.maxSize + 1];
            this.heap[0] = int.MinValue;
        }

        private int Parent(int pos)
        {
            return pos / 2;
        }

        private int LeftChild(int pos)
        {
            return (2 * pos);
        }
        
        private int RightChild(int pos)
        {
            return (2 * pos) + 1;
        }

        private bool IsLeaf(int pos)
        {
            if (pos >= (size / 2) && pos <= size) {
                return true;
            }

            return false;
        }

        private void Swap(int aPos, int bPos)
        {
            int tmp = this.heap[aPos];
            this.heap[aPos] = this.heap[bPos];
            this.heap[bPos] = tmp;
        }

        private void Heapify(int pos)
        {
            if (!IsLeaf(pos))
            {
                if (this.heap[pos] > this.heap[LeftChild(pos)] ||
                    this.heap[pos] > this.heap[RightChild(pos)])
                {
                    if (this.heap[LeftChild(pos)] < this.heap[RightChild(pos)])
                    {
                        Swap(pos, LeftChild(pos));
                        Heapify(LeftChild(pos));
                    }
                    else
                    {
                        Swap(pos, RightChild(pos));
                        Heapify(RightChild(pos));
                    }
                }
            }
        }

        public void Insert(int element)
        {
            int current;

            if (size >= maxSize)
                return;

            this.heap[++size] = element;
            current = size;

            while (this.heap[current] < this.heap[Parent(current)])
            {
                Swap(current, Parent(current));
                current = Parent(current);
            }
        }

        public void Print()
        {
            int i;

            Console.WriteLine("Print Heap:");

            for (i = 1; i <= size / 2; i++)
            {
                Console.Write(" PARENT: " + this.heap[i]
                    + " LEFT CHILD: " + this.heap[2 * i]
                    + " RIGHT CHILD: " + this.heap[2 * i + 1]);

                Console.WriteLine();
            }
        }

        public int GetMin()
        {
            return this.heap[1];
        }

        public int ExtractMin()
        {
            int popped = this.heap[1];
            this.heap[1] = this.heap[size];
            size--;
            // Heapify(1);
            BuildHeap();

            return popped;
        }

        public void DecreaseKey(int pos, int priority)
        {
            if (this.heap[pos] > priority)
            {
                this.heap[pos] = priority;
                Heapify(pos);
            }
        }

        public void BuildHeap()
        {
            int pos;

            for (pos = (size / 2); pos >= 1; pos--)
            {
                Heapify(pos);
            }
        }
    }
}
