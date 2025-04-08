using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures_Algorithms.ProblemSolvingPatterns.PrefixSum
{
    internal class LargestAltitude
    {
        public void Test()
        {
            int[] gain = new int[] { -5, 1, 5, 0, -7 };
            Console.WriteLine(LargestAltitudeImpl(gain));
        }

        private int LargestAltitudeImpl(int[] gain)
        {

            var highestAltitude = 0;
            var lastHeight = 0;

            for (var i = 0; i < gain.Length; i++)
            {
                var currentHeight = gain[i];
                var currentGain = currentHeight + lastHeight;
                highestAltitude = Math.Max(highestAltitude, currentGain);
                lastHeight = currentGain;
            }
            return highestAltitude;
        }
    }
}
