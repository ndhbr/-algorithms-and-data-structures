using System.Collections.Generic;
using System;

namespace exercise_sheet_6
{
    public class ListElement<T>
    {
        private ListElement<T> next;
        private T value;

        public ListElement()
        {
            this.SetNext(null);
        }
        
        public ListElement(T value)
        {
            this.SetNext(null);
            this.value = value;
        }

        public ListElement<T> GetNext()
        {
            return this.next;
        }

        public void SetNext(ListElement<T> element)
        {
            this.next = element;
        }

        public void SetValue(T value)
        {
            this.value = value;
        }

        public T GetValue()
        {
            return this.value;
        }

        public override string ToString()
        {
            return this.value.ToString(); 
        }
    }
}