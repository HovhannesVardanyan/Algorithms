using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Algorithms
{
    /// <summary>
    /// This class was defined to provide solution to the following problem
    /// 
    /// Given an array of size n, find the number of inversions in it.
    /// 
    /// Inversion is defined as follows:
    /// 
    /// if
    /// i is less than j 
    /// 
    /// and
    /// 
    /// a[i] > a[j] then we have an inversion
    /// 
    /// </summary>
    static class Inversions
    {
        public static long NumberOfInversions(int[] arr)
        {
            return DivideAndConquer(arr).num;
        }

        private static (long num , int[] a) DivideAndConquer(int[] arr)
        {
            if (arr.Length == 1)
                return (0,arr);
            int len = arr.Length / 2;

            int[] left = arr.Take(len).ToArray();
            int[] right = arr.Skip(len).ToArray();

            var (l, leftSorted) = DivideAndConquer(left);
            var (r, rightSorted) = DivideAndConquer(right);

            var (a, array) = Merge(leftSorted,rightSorted);

            return ((l + r + a),array); 
        }


        private static (long num, int[] arr) Merge(int[] a, int[] b)
        {
            int[] ans = new int[a.Length + b.Length];
            int index = 0, ia = 0, ib = 0;
            long count = 0;
            while (index < ans.Length)
            {
                if (ia < a.Length && ib < b.Length)
                {
                    if (a[ia] > b[ib])
                    {
                        ans[index++] = b[ib++];
                        count += a.Length - ia;
                    }
                    else
                        ans[index++] = a[ia++];
                }
                else if (ia < a.Length)
                    ans[index++] = a[ia++];
                else
                    ans[index++] = b[ib++];
            }
            return (count,ans);
        }
    }
}
