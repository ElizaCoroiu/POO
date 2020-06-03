using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSortAlgorithm
{
    class HeapSort
    {
        public HeapSort() { }

        public void sort<T>(T[] arr) where T: IComparable<T>
        {
            int n = arr.Length;

            // Build heap
            buildMaxHeap(arr, n);

            // One by one extract an element from heap 
            for (int i = n - 1; i > 0; i--)
            {
                // Move current root to end 
                T aux = arr[0];
                arr[0] = arr[i];
                arr[i] = aux;

                // call max heapify on the reduced heap 
                maxHeapify(arr, 0, i);
            }
        }

        private void buildMaxHeap<T>(T[] arr, int n) where T : IComparable<T>
        {
            for (int i = n/2 - 1; i >= 0; i--)
            {
                maxHeapify(arr, i, n);
            }
        }

        private void maxHeapify<T>(T[] arr, int i, int n) where T : IComparable<T>
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            // If left child is larger than root
            if (left < n && !less(arr[left], arr[largest]))
            {
                largest = left;
            }

            // If right child is larger than largest so far
            if (right < n && !less(arr[right], arr[largest]))
            {
                largest = right;
            }

            // If largest is not root
            if (largest != i)
            {
                T aux = arr[i];
                arr[i] = arr[largest];
                arr[largest] = aux;

                // Recursively heapify the affected sub-tree 
                maxHeapify(arr, largest, n);
            }
        }

        private bool less<T>(T a, T b) where T : IComparable<T>
        {
            return (a.CompareTo(b) < 0);
        }
    }
}
