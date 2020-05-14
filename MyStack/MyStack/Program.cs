using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stiva<int> st1 = new Stiva<int>(4);

            st1.Push(4);
            st1.Push(3);
            st1.Push(2);
            st1.Push(1);

            Console.WriteLine("Stack of integers: ");
            PopAllElements(st1);

            Stiva<string> st2 = new Stiva<string>(10);
            st2.Push("August");
            st2.Push("July");
            st2.Push("June");
            st2.Push("May");
            st2.Push("April");
            st2.Push("March");

            Console.WriteLine("Stack of strings: ");
            PopAllElements(st2);
            
            st2.Clear();
            st2.Pop();

            Console.ReadKey();
        }

        private static void PopAllElements<T>(Stiva<T> st)
        {
            while (!st.Empty)
            {
                Console.WriteLine(st.Pop());
            }
        }
    }
}
