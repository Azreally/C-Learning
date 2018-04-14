// Created by Azzy April, 2018.

// References
using System;
using System.Collections.Generic;
using System.Text;

// Project namespace
namespace GetAllPrimesFromValue
{
    // Mathematic extensions
    static class MathEx
    {
        // Prime generator
        public static int[] GenerePrimes(int value)
        {
            var primes = new List<int>();
            var isprime = false;

            // Get all possible primes
            for (int i = 2; i < ((value / 2) + 1); i++)
            {
                isprime = true;
                // Check if this integer is prime value
                foreach (var prime in primes)
                    if ((i % prime) == 0)
                    {
                        isprime = false;
                        break;
                    }

                // If it is, add it
                if (isprime)
                {
                    primes.Add(i);
                }
            }

            // Get result
            return primes.ToArray();
        }

        // Get all divide primes from value
        public static int[] GetPrimes(int value)
        {
            var primes = new List<int>();
            var temp = value;
            // Get all possible primes
            foreach (var p in GenerePrimes(value))
            {
                temp = value;
                // Check if is divisible by current prime
                while ((temp % p) == 0)
                {
                    temp /= p;
                    primes.Add(p);
                }
            }

            // Get result
            return primes.ToArray();
        }
    }

    // Main class
    class GetAllPrimes
    {
        // Print result
        static void PrintResult(int value)
        {
            // Builds result string
            var result = new StringBuilder();
            result.AppendFormat("For value {0} primes is:{1}", value, Environment.NewLine);
            // Get all primes for passed value
            var primes = MathEx.GetPrimes(value);

            if (primes.Length > 0)
            {
                // Show all divisible primes for this value
                foreach (var prime in primes)
                {
                    result.AppendFormat("{0}, ", prime);
                }
            }
            else
            {
                // When passed value is prime
                result.AppendLine("This value is prime number!");
            }

            // Additional new line
            result.AppendLine();

            // Show result
            Console.WriteLine(result.ToString());
        }

        // Program start procedure
        static void Main(string[] args)
        {
            // Show program information
            Console.WriteLine("Program made by Azzy, compilation date {0}.{1}", 
                DateTime.Now.ToString(), Environment.NewLine);

            var value = 0;
            try
            {
                // Get parameter count
                if (args.Length > 0)
                {
                    // Get all parameters
                    foreach (var argument in args)
                    {
                        if (int.TryParse(argument, out value))
                        {
                            // Print result information
                            PrintResult(value);
                        }
                        else
                        {
                            // Show conversion error message
                            Console.WriteLine("Cannot convert string: \"{0}\" to int!",
                                argument);
                        }
                    }
                }
                else
                {
                    // Get value
                    Console.WriteLine("Pass value to division:");
                    var stringValue = Console.ReadLine();
                    if (int.TryParse(stringValue, out value))
                    {
                        // Print result
                        PrintResult(value);
                    }
                    else
                    {
                        // Show conversion error
                        Console.WriteLine("Cannot convert this string to int!");
                    }
                }

                // Stop before exit
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            catch (Exception error)
            {
                // When something's gone wrong?...
                Console.WriteLine("Something's gone wrong!{0}Details:{0}{1}", Environment.NewLine, error.Message);
            }
        }
    }
}
