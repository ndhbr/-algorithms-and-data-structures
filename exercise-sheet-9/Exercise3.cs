using System;

namespace exercise_sheet_9
{
    public class Exercise3
    {
        public Exercise3()
        {
            HashTable hash = new HashTable();

            hash.Insert(10);
            hash.Insert(22);
            hash.Insert(31);
            hash.Insert(4);
            hash.Insert(15);
            hash.Insert(28);
            hash.Insert(17);
            hash.Insert(88);
            hash.Insert(59);

            hash.PrintTable();
        }
    }

    public class HashTable
    {
        private HashNode[] hashTable;

        public HashTable()
        {
            this.hashTable = new HashNode[11];
        }

        public void Insert(int value)
        {
            this.InsertDoubleHashing(value);
        }

        public void InsertLinearProbing(int value)
        {
            int hashKey = value % hashTable.Length;

            while (hashKey < this.hashTable.Length && this.hashTable[hashKey] != null)
                hashKey += 1;

            this.hashTable[hashKey] = new HashNode(value);
        }
        
        public void InsertQuadraticProbing(int value)
        {
            int c1 = 1;
            int c2 = 3;
            int i = 1;
            int hashKey;

            do
            {
                hashKey = (value + (c1 * i) + (c2 * i)) % this.hashTable.Length;
                i += 1;
            } while (this.hashTable[hashKey] != null);

            this.hashTable[hashKey] = new HashNode(value);
        }

        public void InsertDoubleHashing(int value)
        {
            int i = 1;
            int hashKey;

            do
            {
                hashKey = (this.Hash1(value) + (i * this.Hash2(value))) % this.hashTable.Length;
                i += 1;
            } while (this.hashTable[hashKey] != null);

            this.hashTable[hashKey] = new HashNode(value);
        }

        public void PrintTable()
        {
            int i;

            Console.Write("\nPrinting Table:");

            for (i = 0; i < this.hashTable.Length; i++)
            {
                Console.Write(this.hashTable[i]);
            }

            Console.Write("\n");
        }

        private int Hash1(int value)
        {
            return value;
        }

        private int Hash2(int value)
        {
            return (1 + (value % (this.hashTable.Length - 1)));
        }
    }

    public class HashNode
    {
        private int value;

        public HashNode() {}

        public HashNode(int value)
        {
            this.value = value;
        }

        public int GetValue()
        {
            return this.value;
        }

        public void SetValue(int value)
        {
            this.value = value;
        }
        
        public override string ToString()
        {
            return " " + this.GetValue().ToString();
        }
    }
}