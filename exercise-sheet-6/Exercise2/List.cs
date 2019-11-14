using System;

namespace exercise_sheet_6
{
    public class List<T>
    {

        ListElement<T> head;
        ListElement<T> tail;
    
        public List()
        {
            this.Create();
        }

        private void Create() {}

        public ListElement<T> Append(T value)
        {
            ListElement<T> element = new ListElement<T>(value);

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

        public void Delete(ListElement<int> element)
        {
            ListElement<T> currentElement = this.head;

            while (currentElement.GetNext() != null)
            {
                ListElement<T> nextElement = currentElement.GetNext();

                if (nextElement.Equals(element))
                {
                    if (nextElement.GetNext() == null)
                    {
                        this.tail = currentElement;
                        currentElement.SetNext(null);
                    }
                    else
                    {
                        ListElement<T> newNextElement = nextElement.GetNext();

                        currentElement.SetNext(newNextElement);
                    }

                    break;
                }

                currentElement = currentElement.GetNext();
            }
        }

        public void QuickSort(ListElement<T> start, ListElement<T> end)
        {
            if (start != null && start.Equals(end))
                return;

            ListElement<T> pivotPrev = ParitionLast(start, end);
            QuickSort(start, pivotPrev);

            if (pivotPrev != null && pivotPrev.Equals(start))
                QuickSort(pivotPrev.GetNext(), end);
            else if (pivotPrev != null && pivotPrev.GetNext() != null)
                QuickSort(pivotPrev.GetNext().GetNext(), end);
        }

        private ListElement<T> ParitionLast(ListElement<T> start, ListElement<T> end)
        {
            if (start == end || start == null || end == null)
                return start;

            ListElement<T> pivotPrev = start;
            ListElement<T> curr = start;
            T pivot = end.GetValue();

            T tmp;

            while (start != end)
            {
                if (Convert.ToInt32(start.GetValue()) < Convert.ToInt32(pivot))
                {
                    pivotPrev = curr;
                    tmp = curr.GetValue();
                    curr.SetValue(start.GetValue());
                    start.SetValue(tmp);
                    curr = curr.GetNext();
                }

                start = start.GetNext();
            }

            tmp = curr.GetValue();
            curr.SetValue(pivot);
            end.SetValue(tmp);

            return pivotPrev;
        }

        public ListElement<T> Search(ListElement<T> element)
        {
            ListElement<T> currentElement = this.head;

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
            ListElement<T> currentElement = this.head;

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