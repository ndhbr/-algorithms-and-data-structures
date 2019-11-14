using System;

namespace exercise_sheet_6
{
    public class Ring
    {

        RingElement tail;
        int length;
    
        public Ring()
        {
            this.Create();
            this.length = 0;
        }

        private void Create() {}

        public RingElement Append(int value)
        {
            RingElement element = new RingElement(value);
            
            if (this.length == 0)
            {
                this.tail = element;
                this.tail.SetNext(this.tail);
            }
            else
            {
                element.SetNext(this.tail.GetNext());
                this.tail.SetNext(element);

                this.tail = element;
            }

            this.length++;

            return element;
        }

        public void Delete(RingElement element)
        {
            if (this.length > 0)
            {
                RingElement current = this.tail.GetNext();

                for (int i = 0; i < this.length; i++)
                {
                    if (current.GetNext().Equals(element))
                        current.SetNext(current.GetNext().GetNext());

                    current = current.GetNext();
                }

                this.length--;
            }
        }

        public RingElement Search(RingElement element)
        {
            return null;
        }

        public RingElement PopRandom()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, this.length+1);
            RingElement element = this.tail;

            for(int i = 0; i < randomIndex; i++)
            {
                element = element.GetNext();
            }

            this.Delete(element);

            return element;
        }

        public void Print()
        {
            if (this.length > 0)
            {
                RingElement currentElement = this.tail.GetNext();

                Console.Write("\n");

                do 
                {
                    Console.Write(" " + currentElement.ToString() + " ");

                    currentElement = currentElement.GetNext();
                } while (!currentElement.Equals(this.tail.GetNext()));

                Console.Write("\n");

                Console.WriteLine("Tail: " + this.tail);
            }
        }
    }
}