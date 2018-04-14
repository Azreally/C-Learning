using System;
using System.Collections.Generic;
using System.Text;

namespace GetAllPrimesFromValue
{
    static class MathEx
    {
        public static int[] GenerePrimes(int value)
        {
            var primes = new List<int>();
            var isprime = false;

            for (int i = 2; i < ((value / 2) + 1); i++)
            {
                isprime = true;
                foreach (var prime in primes)
                    if ((i % prime) == 0)
                    {
                        isprime = false;
                        break;
                    }

                if(isprime)
                {
                    primes.Add(i);
                }
            }

            return primes.ToArray();
        }

        public static int[] GetPrimes(int value)
        {
            var primes = new List<int>();
            var temp = value;
            foreach (var p in GenerePrimes(value))
            {
                temp = value;
                while ((temp % p) == 0)
                {
                    temp /= p;
                    primes.Add(p);
                }
            }

            return primes.ToArray();
        }
    }
    class GetAllPrimes
    {
        static void PrintResult(int value){
            var result = new StringBuilder();
            result.AppendFormat("For value {0} primes is:{1}", value, Environment.NewLine);
            var primes = MathEx.GetPrimes(value);

            if (primes.Length > 0)
            {
                foreach (var prime in primes)
                {
                    result.AppendFormat("{0}, ", prime);
                }
            }
            else
            {
                result.AppendLine("This value is prime number!");
            }

            result.AppendLine();

            Console.WriteLine(result.ToString());
        }

        static void Main(string[] args)
        {
            var value = 0;
            try
            {
                if (args.Length > 0)
                {
                    foreach (var argument in args)
                    {
                        if (int.TryParse(argument, out value))
                        {
                            PrintResult(value);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Pass some value:");
                    var stringValue = Console.ReadLine();
                    if (int.TryParse(stringValue, out value))
                    {
                        PrintResult(value);
                    }
                    else
                    {
                        Console.WriteLine("Cannot convert this string to int!");
                    }
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            catch (Exception error)
            {
                Console.WriteLine("Something's gone wrong!{0}Details:{0}{1}", Environment.NewLine, error.Message);
            }
        }
    }
}
