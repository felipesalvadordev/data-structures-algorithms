using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures_Algorithms.ProblemSolvingPatterns.SlidingWindow
{
    internal class MaxCurrentSequence
    {
        public void Test()
        {
            var currentWindow = 0;
            var previousWindow = 0;
            int maxOne = 0;
            int[] nums = { 0, 1, 1, 1, 0, 1, 1, 0, 1 };
            //Max current sequence of 1s ignoring zeros in the sequence.
            //Result 5
            //One window to sum the current sequence of 1 until a 0 appear.
            //Another window to save the last sequence.
            //Both windows will be sum to get the max sequence os 1s.

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    currentWindow++;
                }
                else
                {
                    maxOne = Math.Max(maxOne, previousWindow + currentWindow);
                    previousWindow = currentWindow;
                    currentWindow = 0;
                }
            }

            if (currentWindow == nums.Length)
            {
               currentWindow -= 1;
            }

            Console.WriteLine(Math.Max(maxOne, previousWindow + currentWindow));
        }
    }
}
