using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Security.Principal;
using System.Text;

namespace Data_Structures_Algorithms.ProblemSolvingTechniques.DynamicProgramming
{
    public class LongestCommonSubSequence
    {
        public void Test()
        {
            string s1 = "aa";
            string s2 = "aab";
            Console.Write($"Length of LCS (Recursive) for words {s1} and {s2} is " + LCSRec(s1, s2));
            Console.WriteLine();
            Console.Write($"Length of LCS (Memoization) for words {s1} and {s2} is " + LCSRecMemoization(s1, s2));
            Console.WriteLine();
            Console.Write($"Length of LCS (Tabulation) for words {s1} and {s2} is " + LCSTabulation(s1, s2));
            Console.WriteLine();
            Console.Write($"Length of LCS (Single Array( for words {s1} and {s2} is " + LCSSingleArray(s1, s2));
        }

        #region LCSRec
        //[Naive Approach]  O(2 ^ min(m, n)) Time and O(min(m, n)) Space
        static int LCSRec(string s1, string s2, int m, int n)
        {
            // Base case: If either string is empty, the length of LCS is 0
            if (m == 0 || n == 0)
                return 0;

            // If the last characters of both substrings match
            if (s1[m - 1] == s2[n - 1])
            {
       
                // Include this character in LCS and recur for remaining substrings

                var maxValueFromRecCalls = 1 + LCSRec(s1, s2, m - 1, n - 1);

                Console.Write("char " + s1[m - 1].ToString().ToUpper() + " are equal to " + s2[n - 1].ToString().ToUpper());
                Console.WriteLine();

                Console.Write("max value from rec calls: " + maxValueFromRecCalls);
                Console.WriteLine();

                return maxValueFromRecCalls;
            }

            else
            {
                // If the last characters do not match
                // Recur for two cases:
                // 1. Exclude the last character of S1 
                // 2. Exclude the last character of S2 
                // Take the maximum of these two recursive calls

                int maxValueFromRecCalls = Math.Max(LCSRec(s1, s2, m, n - 1), LCSRec(s1, s2, m - 1, n));

                Console.Write("char " + s1[m - 1].ToString().ToUpper() + " are different to " + s2[n - 1].ToString().ToUpper());
                Console.WriteLine();

                Console.Write("max value from rec calls: " + maxValueFromRecCalls);
                Console.WriteLine();


                return maxValueFromRecCalls;
            }
        }
        static int LCSRec(string s1, string s2)
        {
            int m = s1.Length, n = s2.Length;
            return LCSRec(s1, s2, m, n);
        }
        #endregion

        #region LCSMemoization

        //Using Memoization(Top Down DP) – O(m* n) Time and O(m* n) Space
        static int LCSRecMemoization(string s1, string s2)
        {
            int m = s1.Length;
            int n = s2.Length;
            int[,] dp = new int[m, n];

            // Initialize memo array with -1
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dp[i, j] = -1;
                }
            }

            return LCSRecMemoization(s1, s2, m, n, dp);
        }

        static int LCSRecMemoization(string s1, string s2,int m, int n, int[,] dp)
        {
            //base case 
            if (m == 0 || n == 0)
                return 0;

            //if the same state has already been computed 
            if (dp[m - 1, n - 1] != -1)
            {
                Console.Write("Chars " + s1[m - 1] + " and " + s2[n - 1] + " was already compared.");
                Console.WriteLine();
                return dp[m - 1, n - 1];
            }
            
            //if equal, then we store the value of the function call 
            if (s1[m - 1] == s2[n - 1])
            {
                //store it in arr to avoid 
                //further repetitive work 
                //in future function calls 
                int valueToStoreInMemo = 1 + LCSRecMemoization(s1, s2, m - 1,n - 1, dp);

                Console.Write("char " + s1[m - 1].ToString().ToUpper() + " are equal to " + s2[n - 1].ToString().ToUpper());
                Console.WriteLine();
                Console.Write("value to store in memo array in position " + (m - 1) + "," + (n - 1) + " is:" + valueToStoreInMemo);
                Console.WriteLine();

                dp[m - 1, n - 1] = valueToStoreInMemo;
                return dp[m - 1, n - 1];
            }
            else
            {
                //store it in arr to avoid 
                //further repetitive work 
                //in future function calls 
                int valueToStoreInMemo = Math.Max(LCSRecMemoization(s1, s2, m, n - 1, dp),
                    LCSRecMemoization(s1, s2, m - 1, n, dp));

                Console.Write("char " + s1[m - 1].ToString().ToUpper() + " are different to " + s2[n - 1].ToString().ToUpper());
                Console.WriteLine();
                Console.Write("value to store in memo array in position " + (m - 1) + "," + (n - 1) + " is:" + valueToStoreInMemo);
                Console.WriteLine();

                dp[m - 1, n - 1] = valueToStoreInMemo;

                return dp[m - 1, n - 1];
            }
        }
        #endregion

        #region LCSTabulation

        //Using Bottom-Up DP(Tabulation) – O(m * n) Time and O(m * n) Space
        //Solve the problem iteratively from the base cases up, ensuring that each sub-problem is solved only once.
        static int LCSTabulation(string s1, string s2)
        {
            int m = s1.Length;
            int n = s2.Length;

            //Initializing a matrix of size (m+1)*(n+1)
            //The plus row and column serve as a base case upon which to fill out the rest of the table.
            int[,] dp = new int[m + 1, n + 1];

            // Building dp[m+1][n+1] in bottom-up fashion
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (s2[j - 1] == s1[i - 1])
                    {
                        Console.Write("char " + s1[i - 1].ToString().ToUpper() + " are equal to " + s2[j - 1].ToString().ToUpper());
                        Console.WriteLine();

                        //If the two characters do match, only look at the cell that is diagonally up and to the left,
                        //and then add 1.
                        var cellDiagonnalyUpLeft = dp[i - 1, j - 1];
                        dp[i, j] = cellDiagonnalyUpLeft + 1;


                        Console.Write("Get value of position diagonally up and to the left {" + cellDiagonnalyUpLeft + "} plus 1: " + (cellDiagonnalyUpLeft + 1));
                        Console.WriteLine();
                    }
                    else
                    {
                        //In the case where the two characters from each string do not match,
                        //look at the cells to the left, and to the top.
                        int maxValueFromCellsToTheLeftAndOnTop = Math.Max(dp[i - 1, j], dp[i, j - 1]);

                        dp[i, j] = maxValueFromCellsToTheLeftAndOnTop;

                        Console.Write("char " + s1[i - 1].ToString().ToUpper() + " are different to " + s2[j - 1].ToString().ToUpper());
                        Console.WriteLine();

                        Console.Write("Max value between cells to the left, and to the top: " + maxValueFromCellsToTheLeftAndOnTop);
                        Console.WriteLine();
                    }
                }
            }
            return dp[m, n];
        }

        #endregion

        #region LCSSingleArray

        //Using Bottom-Up DP (Space-Optimization):
        //Using Single Array – O(m * n) Time and O(n) Space
        static int LCSSingleArray(string s1, string s2)
        {
            int m = s1.Length;
            int n = s2.Length;

            // dp array is initialized to all zeros
            int[] dp = new int[n + 1];

            for (int i = 1; i <= m; ++i)
            {
                int prev = dp[0];

                for (int j = 1; j <= n; ++j)
                {
                    // temp temporarily stores the current 
                    // dp[j] before it gets updated
                    int currentTemp = dp[j];
                    if (s1[i - 1] == s2[j - 1])
                    {
                        //If characters match, add 1 to the value 
                        //from the previous row and previous column
                        dp[j] = 1 + prev;
                    }
                    else
                    {
                        int maxValueFromCellsToTheLeftAndOnTop = Math.Max(dp[j - 1], dp[j]);
                        dp[j] = maxValueFromCellsToTheLeftAndOnTop;
                    }

                    // Update for next iteration
                    prev = currentTemp;
                }
            }

            return dp[n];
        }

        #endregion
    }
}
