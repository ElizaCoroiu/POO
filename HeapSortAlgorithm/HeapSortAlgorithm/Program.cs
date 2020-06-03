using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSortAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] months = {"January", "February", "March", "April", "May", "June", 
            "July", "August", "September", "October", "November", "December"};
          
            Console.WriteLine("Array before sorting: ");
            printArray(months);

            HeapSort hs = new HeapSort();
            hs.sort(months);

            Console.WriteLine();
            Console.WriteLine("Array after sorting: ");
            printArray(months);

            Console.ReadKey();
        }

        static void printArray<T>(T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
