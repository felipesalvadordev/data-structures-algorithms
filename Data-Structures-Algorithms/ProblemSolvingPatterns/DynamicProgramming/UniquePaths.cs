using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Data_Structures_Algorithms.ProblemSolvingPatterns.DynamicProgramming
{
    //Calculate the total number of unique paths in a m x n grid the robot can take to reach from the top-left corner
    //to the bottom-right corner.A path is considered unique if it follows a different sequence of moves
    //Top left is grid[0][0] and bottom-right corner is grid[m - 1][n - 1].
    //The robot is restricted to move only in two directions, either down or right, at any given point in time.
    internal class UniquePaths
    {
        public void Test()
        {
            //Example of a combinatorial problem that can be solved using dynamic programming (DP)
            //The time complexity of the provided solution is O(m * n), where m is the number of
            //rows and n is the number of columns

            //The space complexity of the solution is O(n), as it uses a single list f of size n
            //to store intermediary results

            //An m x n grid
            int rowNumbers = 3, columnNumbers = 3;
            //1.Right->Down->Down
            //2.Down->Down->Right
            //3.Down->Right->Down

            // Create an array to store the number of unique paths to each cell in the bottom row.
            int[] pathCounts = new int[columnNumbers];

            // Initialize the bottom row with 1s since there's only one way to reach each cell in the bottom row
            // when only moving right.
            Array.Fill(pathCounts, 1);

            // Loop over each cell starting from the second row up to the top row
            // (since the bottom row is already filled).
            for (int row = 1; row < rowNumbers; row++)
            {
                // For each cell in a row, start from the second column since the first column of any row
                // will only have one unique path, that is moving down from the cell above.
                for (int col = 1; col < columnNumbers; col++)
                {
                    //The number of unique paths is the sum of the current cell to the cell
                    //directly above it and to the cell to the left of it
                    pathCounts[col] += pathCounts[col - 1];
                }
            }

            // Return the number of unique paths to the top-right corner of the grid.
            Console.WriteLine(pathCounts[columnNumbers - 1]);
        }
    }
}
