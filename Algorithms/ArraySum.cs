using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// This class was designed to provide solutions to the following problem
    /// 
    /// Given a sorted array of integers and a number k.
    /// 
    /// Find a pair from the array, whose sum is the closest to k
    /// </summary>
    static class ArraySum 
    {
        public static int ClosestSumOn(this int[] arr, int s) // Better linear solution
        {
            if (arr.Length < 2)
                throw new Exception("The array has to contain at least 2 elements");
            
            int b = 0, e = arr.Length - 1;

            int sum = arr[b] + arr[e];

            while (b < e)
            {
                int temp = arr[b] + arr[e];

                if (Math.Abs(temp - s) < Math.Abs(s - sum))
                    sum = temp;

                if (arr[b] + arr[e] == s)
                    return s;

                else if (arr[b] + arr[e] > s)
                    e--;
                
                else
                    b++;

            }


            return sum;
        }
        public static int ClosestSumInSortedArray2(this int[] arr, int s) // Naive O(n^2) solution
        {
            int sum = arr[0] + arr[arr.Length-1];

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    int temp = arr[i] + arr[j];
                    if (Math.Abs(temp - s) < Math.Abs(s - sum))
                        sum = temp;
                }

            }

            return sum;
        }
    }
}
