using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Structures_Algorithms.Data_Structures.Stacks
{
    //Using Single Stack - O(n) Time and O(n) Space 
    internal class MonotonicStack
    {
        // 1 - Look at the height for a column.
        // 2 - If the height is greater than or equal to the first height at the top of the stack or if the stack is empty, push the height onto the stack.
        // 3 - Otherwise pop from the stack.  The maximum rectangular area that exists for this popped height is then calculated.
        // 4 - Continue to pop until the top stack height is less than the column height from step 1.
        static int LargestRectangleArea(int[] heights)
        {
            Stack<int> stack = new Stack<int>();
            int maxArea = 0;
            int n = heights.Length;
            int[] newHeights = new int[n];
            Array.Copy(heights, newHeights, n); // Add sentinel 0 at the end

            for (int i = 0; i <= n; i++)
            {
                // Process the stack while the current element 
                // is smaller than the element corresponding to 
                // the top of the stack
                while (stack.Count > 0 && (i == n || newHeights[i] < newHeights[stack.Peek()]))
                {
                    //Minus 1 to the get index of the current top height in stack
                    //Index i is the width we came across so far (this width does not include the element
                    //that we are iterating now)
                    //The width is determined by the difference between the current index and the new top of the stack.
                    int maxHeight = newHeights[stack.Pop()];
                    int width = stack.Count == 0 ? i : i - stack.Peek() - 1;
                    maxArea = Math.Max(maxArea, maxHeight * width);
                }
                stack.Push(i);
            }

            return maxArea;
        }

        public void Test()
        {
            int[] areas = { 2, 1, 5, 6, 2, 3 };//10
            //int[] areas = { 1, 2, 3, 4, 5 };//9
            //int[] areas = { 11, 11, 10, 10, 10 };//50
            Console.WriteLine($"Largest rectange in histogram bars is: {LargestRectangleArea(areas)}"); 
        }
    }
}
