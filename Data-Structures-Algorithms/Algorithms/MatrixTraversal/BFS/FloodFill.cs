using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Data_Structures_Algorithms.Algorithms.MatrixTraversal.BFS
{
    //Create an empty queue
    //Push the starting location of the pixel as given in the input and apply the replacement color to it.
    //Iterate until Q is not empty and pop the front node(pixel position).
    //Check the pixels adjacent to the current pixel and push them into the queue if valid(had not been colored
    //with replacement color and have the same color as the old color).

    //BFS uses a queue to explore all reachable pixels level by level (horizontally and vertically)
    //Time Complexity: O(m * n), as all pixels are visited once in BFS.

    internal class FloodFill
    {
        public void Test()
        {
            int[,] image = {
                {1, 1, 1},
            {1, 1, 0},
            {1, 0, 1}
        };

            int sr = 1, sc = 1, newColor = 2;

            Console.WriteLine("Original pixel matrix");
            PrintArray(image);
            Console.WriteLine();

            int[,] result = FloodFillImpl(image, sr, sc, newColor);

            Console.WriteLine();
            Console.WriteLine("Matrix traversed");
            PrintArray(result);
        }

        // BFS-based Flood Fill implementation
        public static int[,] FloodFillImpl(int[,] imageMatrix,
                                       int sr, int sc,
                                       int newColor)
        {
            Queue<(int, int)> lastPixelsCoordinates = new Queue<(int, int)>();

            // Get the original color of the starting pixel
            int oldColor = imageMatrix[sr, sc];

            if (oldColor == newColor)
               return imageMatrix;

            // Dimensions of the matrix
            int rows = imageMatrix.GetLength(0);
            int cols = imageMatrix.GetLength(1);


            // Add the starting pixel to the queue
            lastPixelsCoordinates.Enqueue((sr, sc));

            // Change the starting central pixel color
            imageMatrix[sr, sc] = newColor;

            Console.WriteLine("Color changed in the first coordinates");
            PrintArray(imageMatrix);
            Console.WriteLine();

            //// Direction vectors for adjacent pixels
            int[] directionsForRow = { -1, 1, 0, 0 };
            int[] directionsForColumn = { 0, 0, -1, 1 };

            // BFS loop
            while (lastPixelsCoordinates.Count > 0)
            {
                (int lastRow, int lastColumn) = lastPixelsCoordinates.Dequeue();

                //Traverse all 4 directions (north, south, east, west)
                for (int i = 0; i < directionsForRow.Length; i++)
                {
                    int nextRow = lastRow + directionsForRow[i];
                    int nextColumn = lastColumn + directionsForColumn[i];

                    // Check boundary conditions and color match
                    if (nextRow >= 0 && nextRow < rows && nextColumn >= 0
                                && nextColumn < cols
                                && imageMatrix[nextRow, nextColumn] == oldColor)
                    {
                        Console.WriteLine("Next coordinates (row " + nextRow + " and column " + nextColumn + ")");
                        Console.WriteLine();

                        imageMatrix[nextRow, nextColumn] = newColor;
                        Console.WriteLine("Color change");
                        PrintArray(imageMatrix);
                        Console.WriteLine();

                        // Add the pixel to the queue
                        lastPixelsCoordinates.Enqueue((nextRow, nextColumn));
                        Console.WriteLine("Queue enqueue with next last coordinates (row " + nextRow + " and column " + nextColumn + ")");
                    }
                }
            }

            return imageMatrix;
        }

        // Method to print the 2D array
        public static void PrintArray(int[,] image)
        {
            for (int i = 0; i < image.GetLength(0); i++)
            {
                for (int j = 0; j < image.GetLength(1); j++)
                {
                    Console.Write(image[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
