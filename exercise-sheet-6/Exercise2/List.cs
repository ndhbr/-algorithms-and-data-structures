using System;

namespace exercise_sheet_6
{
    public class List
    {

        ListElement head;
        ListElement tail;
    
        public List()
        {
            this.Create();
        }

        private void Create() {}

        public ListElement Append(int value)
        {
            ListElement element = new ListElement(value);

            if (head == null)
            {
                this.head = element;
                this.tail = this.head;
            }
            else
            {
                this.tail.SetNext(element);
                this.tail = element;
            }

            return element;
        }

        public void Delete(ListElement element)
        {
            ListElement currentElement = this.head;

            while (currentElement.GetNext() != null)
            {
                ListElement nextElement = currentElement.GetNext();

                if (nextElement.Equals(element))
                {
                    if (nextElement.GetNext() == null)
                    {
                        this.tail = currentElement;
                        currentElement.SetNext(null);
                    }
                    else
                    {
                        ListElement newNextElement = nextElement.GetNext();

                        currentElement.SetNext(newNextElement);
                    }

                    break;
                }

                currentElement = currentElement.GetNext();
            }
        }

        public void QuickSort(List a, ListElement first, ListElement last)
        {
            if (first == last)
                return;

            ListElement pivotPrev = PartitionLast(first, last);
            QuickSort(a, first, pivotPrev);


            if (pivotPrev != null && pivotPrev.Equals(first))
                QuickSort(a, pivotPrev.GetNext(), last);
            else if (pivotPrev !=  null && pivotPrev.GetNext() != null)
                QuickSort(a, pivotPrev.GetNext().GetNext(), last);
        }

        private ListElement PartitionLast(ListElement start, ListElement end)
        {
            if (start == end || start == null || end == null)
                return start;

            ListElement pivotPrev = start;
            ListElement curr = start;
    
            int pivot = end.GetValue();

            int temp;

            while (!start.Equals(end))
            {
                if (start.GetValue() < pivot)
                {
                    pivotPrev = curr;
                    temp = curr.GetValue();
                    curr.SetValue(start.GetValue());
                    start.SetValue(temp);
                    curr = curr.GetNext();
                }

                start = start.GetNext();
            }

            temp = curr.GetValue();
            curr.SetValue(pivot);
            end.SetValue(temp);

            return pivotPrev;
        }

        public ListElement getTail()
        {
            return this.tail;
        }

        public ListElement getHead()
        {
            return this.head;
        }

        public ListElement Search(ListElement element)
        {
            ListElement currentElement = this.head;

            while (currentElement != null)
            {
                if (currentElement.Equals(element))
                    return currentElement;

                currentElement = currentElement.GetNext();
            }

            return null;
        }

        public void Print()
        {
            ListElement currentElement = this.head;

            Console.Write("\n");

            while (currentElement != null)
            {
                Console.Write(" " + currentElement.ToString() + " ");
                currentElement = currentElement.GetNext();
            }

            Console.Write("\n");

            Console.WriteLine("Head: " + this.head + ", Tail: " + this.tail);
        }
    }
}