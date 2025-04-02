using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures_Algorithms.ProblemSolvingPatterns.Recursion
{
    internal class GCD
    {
        public void Test()
        {
            Console.WriteLine(GreatestCommonDivisorOfStrings("ABCABC", "ABC"));//Return ABC
            Console.WriteLine(GreatestCommonDivisorOfStrings("LEET", "CODE"));//Return empty
        }

        public string GreatestCommonDivisorOfStrings(string str1, string str2)
        {
            //No gcd to return
            if (!(str1 + str2).Equals(str2 + str1))
                return "";
            //fetch gcd max length to later parse from the original string
            int gcdlength = GcdHelper(str1.Length, str2.Length);
            // substring the original string to fetch only the part we know is the gcd
            return str1.Substring(0, gcdlength);
        }
        public static int GcdHelper(int x, int y)
        {
            // if x is 0 then the whole gcd is x, if it is not calculate gcd using euclides algorithm
            if (y == 0)
                return x;
            else
                return GcdHelper(y, x % y);
        }
    }
}
