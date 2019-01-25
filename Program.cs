using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Number");
            int n = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine();
            intro_sort_project sp = new intro_sort_project();
            int[] array = new int[n];
            array = sp.random_numbers(n);
            sp.insertionsort(array);
            sp.quickSort(array, 0, array.Length - 1);
            Console.WriteLine("Data After Apply Sorting");
            int[] array1 = new int[n];
            array1 = sp.IntroSort(array);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}", array1[i]);
            }
        }
    }
    class intro_sort_project
    {
        public int[] random_numbers(int n)
        {
            Random rnd = new Random();
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = rnd.Next(n);
                Console.WriteLine(a[i]);
            }
            return a;
        }
        public int[] insertionsort(int[] array)
        {
            int inner, key;
            for (int outer = 0; outer < array.Length; outer++)
            {
                key = array[outer];
                inner = outer;
                while (inner > 0 && array[inner - 1] >= key)
                {
                    array[inner] = array[inner - 1];
                    inner -= 1;
                }
                array[inner] = key;
            }
            return array;
        }
        public int partition(int[] arr, int low,
                       int high)
        {
            int pivot = arr[high];

            // index of smaller element 
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                // If current element is smaller  
                // than or equal to pivot 
                if (arr[j] <= pivot)
                {
                    i++;

                    // swap arr[i] and arr[j] 
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            // swap arr[i+1] and arr[high] (or pivot) 	
            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i + 1;
        }
        public void quickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {

                int pi = partition(arr, low, high);

                // Recursively sort elements before 
                // partition and after partition 
                quickSort(arr, low, pi - 1);
                quickSort(arr, pi + 1, high);
            }
        }
        public int[] IntroSort(int[] data)
        {
            int partitionSize = partition(data, 0, data.Length - 1);

            if (partitionSize < 16)
            {
                insertionsort(data);
            }
            else if (partitionSize > (2 * Math.Log(data.Length)))
            {
                HeapSort(data);
            }
            else
            {
                quickSort(data, 0, data.Length - 1);
            }
            return data;
        }
        public void HeapSort(int[] data)
        {
            int heapSize = data.Length;

            for (int p = (heapSize - 1) / 2; p >= 0; --p)
                MaxHeapify(data, heapSize, p);

            for (int i = data.Length - 1; i > 0; --i)
            {
                int temp = data[i];
                data[i] = data[0];
                data[0] = temp;

                --heapSize;
                MaxHeapify(data, heapSize, 0);
            }
        }
        public void MaxHeapify(int[] data, int heapSize, int index)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest = 0;

            if (left < heapSize && data[left] > data[index])
                largest = left;
            else
                largest = index;

            if (right < heapSize && data[right] > data[largest])
                largest = right;

            if (largest != index)
            {
                int temp = data[index];
                data[index] = data[largest];
                data[largest] = temp;

                MaxHeapify(data, heapSize, largest);
            }
        }
    }
}


