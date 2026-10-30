using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventures_in_words
{
    public static class RandomNumberGenerator
    {
        private static Random random = new Random();
        private static List<int> usedNumbers = new List<int>();

        public static int GenerateUniqueRandomNumber(int minValue, int maxValue)
        {
            int number;

            do
            {
                number = random.Next(minValue, maxValue + 1);
            }
            while (usedNumbers.Contains(number));

            usedNumbers.Add(number);

            if (usedNumbers.Count == maxValue - minValue + 1)
            {
                usedNumbers.Clear();
            }

            return number;
        }
    }

}

