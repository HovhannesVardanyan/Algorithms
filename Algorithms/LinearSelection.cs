using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// This class was designed to provide the implementation of two solutions to the following problem.
    /// 
    /// Given an array of size n, find the ith order statistic (ith smallest element)
    /// </summary>
    static class LinearSelection
    {
        private static Random random = new Random();
        /// <summary>
        /// The first approach is choosing the element randomly,which can result into quadratic runtime. 
        /// However, the probabilistic analysis shows that the expected running time of this algorithm is linear.
        /// </summary>
        public static int RandomizedSelect(int[] arr, int i) 
        {
            if (i > arr.Length)
                throw new ArgumentException($"There has to be at least {i} elements not {arr.Length}");

            return RandomizedSelect(arr, 0, arr.Length - 1, i);
        }
        private static int RandomizedSelect(int[] arr, int begin, int end, int i)
        {
            if (begin == end)
                return arr[begin];

            int ind = random.Next(begin, end + 1);
            
            int pivot = Sort.Partition(arr, begin, end, ind);

            int order = pivot - begin + 1;

            if (order == i)
                return arr[pivot];
            else if (order < i)
                return RandomizedSelect(arr, pivot + 1, end, i - order);

            return RandomizedSelect(arr, begin, pivot - 1, i);
        }


        /// <summary>
        /// The second approach is the choosing the median of medians.This is called Deterministic Selection. Unlike the randomized approach, this 
        /// algorithm has a guaranteed running time of O(n).
        /// </summary>
        public static int DeterministicSelection(int[] arr, int i)
        {
            return DeterministicSelection(arr,0, arr.Length -1, i);
        }
        private static int DeterministicSelection(int[] arr,  int begin, int end, int i)
        {
            if (end - begin <= 5)
            {
                int[] b = arr.SubArray(begin, end);
                Array.Sort(b);
                return b[i - 1];
            }

            int[] medians = new int[(arr.Length + 4) / 5];

            for (int k = 0; k < medians.Length; k++)
            {
                int[] a = new int[Math.Min(5, arr.Length - 5*k)];

                for (int p = 5 * k; p < 5 * (k + 1) && p < arr.Length; p++)
                {
                    a[p - 5 * k] = arr[p];
                }
                Array.Sort(a);

                medians[k] = a[Median(a)];
            }
            
            int median = DeterministicSelection(medians, 0, medians.Length - 1,medians.Length / 2);

            int medianIndex = begin;

            for (int k = begin; k <= end; k++)
                if (arr[k] == median)
                    medianIndex = k;

            int pivotIndex = Sort.Partition(arr,0,arr.Length - 1,medianIndex);

            int order = pivotIndex + 1 - begin;

            if (order == i)
                return arr[pivotIndex];
            else if (order < i)
                return DeterministicSelection(arr, pivotIndex  + 1, end , i - order);

            return DeterministicSelection(arr, begin, pivotIndex - 1, i);

        }


        private static int[] SubArray(this int[] arr, int i, int j)
        {
            int[] a = new int[j - i + 1];

            for (int k = i; k <= j; k++)
            {
                a[k - i] = arr[k];
            }
            return a;
        }
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = a;
        }
        private static int Median(int[] arr)
        {
            int n = arr.Length;
            return (n % 2 != 0) ? (n + 1) / 2 - 1 : n / 2 - 1;
        }


    }
}
