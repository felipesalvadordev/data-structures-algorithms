using System;

namespace Data_Structures_Algorithms.ProblemSolvingPatterns.SlidingWindow
{
    internal class MaxConsecutiveChars
    {
        static void Main(string[] args)
        {
            //int[] nums = {1,1,1,0,0,0,1,1,1,1,0 }; //Result 6
            //int k = 2;

            int[] nums = { 0, 0, 0, 1 };//Result 4
            int k = 4;
            Console.WriteLine(LongestOnes(nums, k));
        }
        static int LongestOnes(int[] nums, int k)
        {
            //Two pointers are used to manage the window of consecutive 1s.
            //The right pointer expands the window to include more elements.
            //When the left pointer moves to the right, it reduces the size of the
            //window when too many 0s have been flipped.
            //The difference r - l gives the maximum length of the subarray with all 1s,
            //considering at most k flips from 0 to 1.

            int left = 0;
            int right = 0;
            int maxOnesCount = 0; // Variable to store the count of continuous ones

            while (right < nums.Length)
            { // Iterate until the right pointer reaches the end of the array
              // If the element at the right pointer is 0, we have to use one flip
                if (nums[right] == 0)
                    k--;

                right++; // Move the right pointer to the next element

                // If we have used all our flips, we need to move the left pointer forward to find a new window
                while (k < 0)
                {
                    // If we are moving the left pointer over a zero, we can have one more flip available
                    if (nums[left] == 0)
                        k++;

                    left++; // Move the left pointer to the next element
                }

                // Update the maximum number of continuous ones found
                maxOnesCount = Math.Max(maxOnesCount, right - left);
            }

            return maxOnesCount;
        }
    }
}
