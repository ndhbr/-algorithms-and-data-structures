using System.Collections.Generic;
using System;

namespace exercise_sheet_6
{
    public class RingElement
    {
        private RingElement next;
        private int value;

        public RingElement()
        {
            this.SetNext(null);
        }
        
        public RingElement(int value)
        {
            this.SetNext(null);
            this.value = value;
        }

        public RingElement GetNext()
        {
            return this.next;
        }

        public void SetNext(RingElement element)
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