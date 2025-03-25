using System;

namespace Data_Structures_Algorithms.Algorithms.Graph.DFS
{
    //Given a 2D image image[][] where each image[i][j] is an integer representing
    //the color of that pixel also given a coordinate

    //imageMatrix = [[1,1,1],[1,1,0],[1,0,1]],
    //starting_row = 1, starting_column = 1,
    //newColor = 2

    //Result: [[2,2,2],[2,2,0],[2,0,1]]
    //The idea is to use Breadth-First Search (BFS) to change all connected
    //pixels with the same color (oldColor) to a new color (newColor).

    //From the center of the imageMatrix(with position (sr, sc) = (1, 1)),
    //all pixels connected by a path of the same color as the starting pixel are
    //colored with the new color

    //Time Complexity: O(m* n), where m and n are the dimensions of the image,
    //as each pixel is visited once

    internal class FloodFill
    {
        public void Test()
        {
            int[,] imageMatrix = {
            {1, 1, 1},
            {1, 1, 0},
            {1, 0, 1}
        };

            Console.WriteLine("Original pixel matrix");
            PrintArray(imageMatrix);
            Console.WriteLine();

            //row 1 and column 1 to start from the center of the image
            int sr = 1, sc = 1, newColor = 2;
            int[,] result = FloodFillImpl(imageMatrix, sr, sc, newColor);

            PrintArray(result);
        }
        public static int[,] FloodFillImpl(int[,] imageMatrix,
                                  int sr, int sc,
                                  int newColor)
        {
            // Get the original color of the starting pixel
            int oldColor = imageMatrix[sr, sc];

            // If the starting pixel already has the new 
            // color, return the image
            if (oldColor == newColor)
                return imageMatrix;
            
            // Call DFS with the starting pixel's original color
            Dfs(imageMatrix, sr, sc, imageMatrix[sr, sc], newColor, "Start");

            return imageMatrix;
        }

        private static void Dfs(int[,] imageMatrix, int row,
                                int column, int oldColor,
                                int newColor, String directionToLog)
        {

            // Check boundary conditions and color match
            if (row < 0 || row >= imageMatrix.GetLength(0) ||
                column < 0 || column >= imageMatrix.GetLength(1) ||
                imageMatrix[row, column] != oldColor)
                return;

            Console.WriteLine(directionToLog);
            Console.WriteLine();

            imageMatrix[row, column] = newColor;
            Console.WriteLine("Color change");
            PrintArray(imageMatrix);
            Console.WriteLine();

            // Visit all adjacent pixels of current coordinate doing DFS in four directions
            Dfs(imageMatrix, row + 1, column, oldColor, newColor, "South");//go south
            Dfs(imageMatrix, row - 1, column, oldColor, newColor, "North");//go north
            Dfs(imageMatrix, row, column + 1, oldColor, newColor, "East");//go east
            Dfs(imageMatrix, row, column - 1, oldColor, newColor, "West");//go west
        }

        public static void PrintArray(int[,] imageMatrix)
        {
            for (int i = 0; i < imageMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < imageMatrix.GetLength(1); j++)
                {
                    Console.Write(imageMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
