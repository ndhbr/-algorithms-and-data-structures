using System.Collections.Generic;
using System;

namespace exercise_sheet_6
{
    public class ListElement
    {
        private ListElement next;
        private int value;

        public ListElement()
        {
            this.SetNext(null);
        }
        
        public ListElement(int value)
        {
            this.SetNext(null);
            this.value = value;
        }

        public ListElement GetNext()
        {
            return this.next;
        }

        public void SetNext(ListElement element)
        {
            this.next = element;
        }

        public void SetValue(int value)
        {
            this.value = value;
        }

        public int GetValue()
        {
            return this.value;
        }

        public override string ToString()
        {
            return this.value.ToString(); 
        }
    }
}