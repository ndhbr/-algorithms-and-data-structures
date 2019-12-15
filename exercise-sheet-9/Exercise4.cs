using System;

namespace exercise_sheet_9
{
    public class Exercise4
    {
        public Exercise4()
        {
            SkipList list = new SkipList();
            list.Insert(3);
            list.Insert(13);
            list.Insert(12);
            list.Insert(5);
            list.Insert(20);
            list.Print();

            bool a = list.Search(5);
            bool b = list.Search(33);

            list.Delete(3);
            list.Delete(12);
            list.Delete(33);
            list.Print();
        }
    }

    public class SkipList
    {
        private Node head;
        private Node tail;
        private int height;
        public int maxHeight;

        private Node[] update;

        public SkipList()
        {
            height = 0;
            maxHeight = 0;

            head = new Node(Int32.MinValue, 0);
            tail = new Node(Int32.MaxValue, 0);

            head.next[0] = tail;

            update = new Node[height+1];
        }

        public void DeInit()
		{
			height = 0;
            maxHeight = 0;

            head = new Node(Int32.MinValue, 0);
            tail = new Node(Int32.MaxValue, 0);

            head.next[0] = tail;

            update = new Node[height+1];
		}

        public void Print()
        {
            int i;

            for (i = this.height; i >= 0; i--)
            {
                Node q = head.next[i];
                Node p = head.next[0];

                while (p != tail)
                {
                    if (q == p)
                    {
                        Console.Write(p.key + " ");
                        p = p.next[i];
                    }
                    else
                    {
                        Console.Write("     ");
                    }

                    q = q.next[0];
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public void Insert(int key)
        {
            int i;
            Node p = head;

            for (i = height; i >= 0; i--)
            {
                while (p.next[i].key < key)
                {
                    p = p.next[i];
                }

                update[i] = p;
            }

            p = p.next[0];

            if (p.key == key)
            {
                Console.WriteLine("Schlüssel " + key + " bereits vorhanden.");
                return;
            }

            int newHeight = this.RandomHeight();

            if (newHeight > maxHeight)
            {
                Node oldHead = head;
                head = new Node(Int32.MinValue, newHeight);

                for (i = 0; i <= maxHeight; i++)
                {
                    head.next[i] = oldHead.next[i];
                }

                for (i = maxHeight+1; i <= newHeight; i++)
                {
                    head.next[i] = tail;
                }

                maxHeight = newHeight;

                for (i = height; i >= 0 && update[i] == oldHead; i--)
                {
                    update[i] = head;
                }

                Node[] oldUpdate = update;
                update = new Node[newHeight+1];

                for (i = 0; i <= height; i++)
                {
                    update[i] = oldUpdate[i];
                }
            }

            if (newHeight > height)
            {
                for (i = height + 1; i <= newHeight; i++)
                {
                    update[i] = head;
                }

                height = newHeight;
            }

            p = new Node(key, newHeight);

            for (i = 0; i <= newHeight; i++)
            {
                p.next[i] = update[i].next[i];
                update[i].next[i] = p;
            }
        }

        public void Delete(int key)
        {
            int i;
            Node p = head;
            Node[] update = new Node[height+1];

            for (i = height; i >= 0; i--)
            {
                while (p.next[i].key < key)
                {
                    p = p.next[i];
                }

                update[i] = p;
            }

            p = p.next[0];

            if (p.key != key)
            {
                Console.WriteLine("Schlüssel " + key + " nicht vorhanden.");
                return;
            }

            for (i = 0; i < p.next.Length; i++)
            {
                update[i].next[i] = update[i].next[i].next[i];
            }

            while (height >= 0 && head.next[height] == tail)
            {
                height--;
            }

            if (4 * height <= maxHeight)
            {
                maxHeight = 2 * height;
                
                Node oldHead = head;
                head = new Node(Int32.MinValue, maxHeight);

                for (i = 0; i <= maxHeight; i++)
                {
                    head.next[i] = oldHead.next[i];
                }

                update = new Node[maxHeight + 1];
            }
        }

        public bool Search(int key)
        {
            int i;
            Node p = head;

            for (i = height; i >= 0; i--)
            {
                while (p.next[i].key < key)
                {
                    p = p.next[i];
                }
            }

            p = p.next[0];

            if (p.key == key && p != tail)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int RandomHeight()
        {
            Random zzGenerator = new Random();
            return zzGenerator.Next(0, this.maxHeight);
        }
    }

    public class Node
    {
        public int key;

        public Node[] next;

        public Node(int key, int height)
        {
            this.key = key;
            this.next = new Node[height+1];
        }
    }
}