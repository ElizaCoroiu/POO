using System;

namespace MyStack
{
    public class Stiva<T> 
    {
        private T[] elements;
        private int currentPosition = 0;

        public bool Empty
        {
            get
            {
                if (currentPosition != 0)
                {
                    return false;
                }
                return true;
            }
        }
        public Stiva(int maxCount)
        {
            elements = new T[maxCount];
        }

        public void Push(T x)
        {
            if (currentPosition < elements.Length)
            {
                elements[currentPosition++] = x;
            }
            else
            {
                throw new StackFullException("Stack is full!");
            }
        }

        public T Pop()
        {
            if (!this.Empty)
            {
                currentPosition--;
                return elements[currentPosition];
            }
            else
            {
                throw new StackEmptyException("Stack is empty!");
            }
        }

        public void Clear()
        {
            elements = new T[elements.Length];
        }
    }
}