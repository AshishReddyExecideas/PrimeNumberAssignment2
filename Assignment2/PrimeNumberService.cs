using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class PrimeNumberService
    {
        private int minValue;
        private int maxValue;
        public static Dictionary<int,bool> dict = new();

        
        private void CreateRandomRange()
        {
            bool hasOldRange = minValue > 0 && maxValue > 0;
            Random rnd = new Random();
            if (!hasOldRange)
            {
                minValue = rnd.Next();
            }
            else
            {
                minValue = rnd.Next(maxValue, int.MaxValue);
            }

            maxValue = rnd.Next(minValue + 1000, int.MaxValue);
        }

        internal int GenerateRandomPrimeNumber()
        {
            CreateRandomRange();
            for (int i = minValue; i <= maxValue; i++) 
            {
                if (IsItPrime(i))
                    return i;
            }

            return GenerateRandomPrimeNumber();
        }

        private bool IsItPrime(int n)
        {
            if(dict.ContainsKey(n))
            {
                return dict[n];
            }
            else
            {
                if (n <= 1)
                {
                    dict.Add(n, false);
                }

                if (n == 2 || n == 3)
                {
                    dict.Add(n, true);
                }
                else if (n % 6 == 1 || n % 6 == 5)
                {
                    var sqrt = Math.Sqrt(n);
                    for (int i = 2; i <= sqrt; i++)
                    {
                        if ((n % i) == 0)
                        {
                            dict.Add(n, false);
                        }
                    }

                    dict.Add(n, true);
                }
                else
                {
                    dict.Add(n, false);
                }
                return dict[n];
            }
        }
    }
}
