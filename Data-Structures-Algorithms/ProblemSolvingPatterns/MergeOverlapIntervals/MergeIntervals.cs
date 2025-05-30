using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Data_Structures_Algorithms.ProblemSolvingPatterns.MergeIntervals
{
    public class MergeIntervals
    {
        public void Test()
        {
            int[][] arr = new int[][] {
            new int[] { 7, 8 },
            new int[] { 1, 5 },
            new int[] { 2, 4 },
            new int[] { 4, 6 }
        };
            List<int[]> res = MergeOverlap(arr);

            foreach (var interval in res)
                Console.WriteLine($"{interval[0]} {interval[1]}");

            //Output: [[1, 6], [7, 8]]
        }

        // O(n*log(n)) Time and O(n) Space
        //The intuition is to first sort the intervals based on their starting points
        static List<int[]> MergeOverlap(int[][] arr)
        {
            // Sort intervals based on start values
            Array.Sort(arr, (a, b) => a[0].CompareTo(b[0]));
            List<int[]> res = new List<int[]>
            {
                new int[] { arr[0][0], arr[0][1] }
            };

            for (int i = 1; i < arr.Length; i++)
            {
                int[] last = res[res.Count - 1];
                int[] curr = arr[i];

                //If the second value of last interval is greater than the first value of the current interval
                //If true, they can be overlapped/merged comparing the max of intervals second values
                if (last[1] > curr[0])
                    last[1] = Math.Max(last[1], curr[1]);
                else
                    res.Add(new int[] { curr[0], curr[1] });
            }

            return res;
        }
    }
}
