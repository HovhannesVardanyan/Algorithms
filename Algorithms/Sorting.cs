using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// This class contains the implemenatation of QuickSort algorithm
    /// </summary>
    static class Sort
    {
        static Random random = new Random();
        public static void QuickSort<T>(this IList<T> arr) where T : IComparable<T>
        {
            int count = 0;
            QuickSort(arr, 0, arr.Count - 1,ref count);
        }
        private static void QuickSort<T>(IList<T> a, int begin, int end,ref int count) where T : IComparable<T>
        {
            if (end - begin < 1)
                return;

            count += end - begin;

            int pivotIndex = ChoosePivot(a, begin, end);
            int ind = Partition(a, begin, end, pivotIndex);
            

            QuickSort(a, begin, ind - 1,ref count);
            QuickSort(a, ind + 1, end,ref count);
        }
        private static int ChoosePivot<T>(IList<T> a, int begin, int end) where T : IComparable<T>
        {
            return random.Next(begin, end + 1);
        }
        public static int Partition<T>(IList<T> a, int begin, int end, int pivotIndex) where T : IComparable<T> 
        {
            if (pivotIndex < begin || pivotIndex > end)
                throw new Exception("Something went wrong with the sorting algorithm", new Exception("The pivot index was not  in the range of a subarray!"));
            a.Swap(begin, pivotIndex);
            int i = begin + 1;
            for (int j = begin + 1; j <= end;j++)
            {
                if (a[begin].CompareTo(a[j]) > 0)
                {
                    a.Swap( i,  j);
                    i++;
                }
            }
            a.Swap(begin,  i - 1);
            return i-1;
        }
        private static void Swap<T>(this IList<T> list, int a,  int b)
        {
            T temp = list[a];
            list[a] = list[b];
            list[b] = temp;
        }
    }
}
