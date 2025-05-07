using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures_Algorithms.ProblemSolvingTechniques.SlidingWindow
{
    public class MaxSumOfSubArray
    {
        public void Test()
        {
            int[] arr = { 1, 4, 2, 10, 2, 3, 1, 0, 20 }; //Max sum is 20 + 0 + 1 + 3
            int k = 4;//Min elements used for the count
            Console.WriteLine(MaxSum(arr, k));
        }

        static int MaxSum(int[] nums, int k)
        {

            // n must be greater
            if (nums.Length <= k)
            {
                Console.WriteLine("Invalid");
                return -1;
            }

            // Compute sum of first window of size k
            int window_sum = 0;

            for (int i = 0; i < k; i++)
                window_sum += nums[i];

            // Compute sums of remaining windows by
            // removing first element of previous
            // window and adding last element of
            // current window.

            int max_sum = window_sum;

            for (int i = k; i < nums.Length; i++)
            {
                window_sum -= nums[i];//Remove element leaving window
                window_sum += nums[i - k];//Add new element entering window
                max_sum = Math.Max(max_sum, window_sum);
            }

            return max_sum;
        }

        //Complexity is O(n).
    }
}
