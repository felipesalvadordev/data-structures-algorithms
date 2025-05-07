using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures_Algorithms.ProblemSolvingPatterns.SlidingWindow
{
    internal class SmallestSubArrayWithGivenSum
    {
        public void Test()
        {
            int[] arr = { 1, 4, 2, 10, 2, 3, 1, 0, 20 };
            SmallestSubarrayWithGivenSum(arr, 7);
        }

        private int SmallestSubarrayWithGivenSum(int[] arr, int S)
        {
            int minLen = Int32.MaxValue;
            // it will hold the size of smallest subarray
            // Integer.MAX_VALUE is the greatest number a int can hold
            // we need the minimum length/size so we will compare others with it. 
            int windowSum = 0, windowStart = 0;
            // windowSum holds sum of the elements in that window
            // windowStart holds the starting position of current window

            for (int windowEnd = 0; windowEnd < arr.Length; windowEnd++)
            {
                // iterating through every element using windowEnd
                windowSum += arr[windowEnd];
                // element is added to the window
                while (windowSum >= S)
                {
                    // while windowSum is greater than equal to S
                    minLen = Math.Min(minLen, windowEnd - windowStart + 1);
                    // compares min len of window with the current window
                    windowSum -= arr[windowStart];
                    // removing the element at the start of the window
                    windowStart++;
                    // moving the window start position to the next place
                }
            }

            return minLen == Int32.MaxValue ? 0 : minLen;
            // ternary operator:
            // if minLen is equal to Integer.MAX_VALUE means minimun window
            // with given sum greater than equal to S is not there. So, it
            // return 0 else it return minLen
        }
    }
}
