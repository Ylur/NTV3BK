// Program.cs
using System;
using System.Collections.Generic;

namespace Verkefni1  // <-- Match the same namespace as in WeatherData.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            // Call either challenge you want to test
            // RunChallenge1();  // For smallest/largest number
            RunChallenge2();     // For WeatherData
        }

        static void RunChallenge1()
        {
            List<int> numbers = new List<int>();

            while (true)
            {
                Console.Write("Enter a number (or press ENTER to finish): ");
                // string input = Console.ReadLine(); // If using C# 8 or earlier
                string? input = Console.ReadLine();   // If using .NET 6/7 with nullable types

                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }

                if (int.TryParse(input, out int number))
                {
                    numbers.Add(number);
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter a valid integer or press ENTER to stop.");
                }
            }

            if (numbers.Count > 0)
            {
                int minValue = int.MaxValue;
                int maxValue = int.MinValue;

                foreach (var num in numbers)
                {
                    if (num < minValue) minValue = num;
                    if (num > maxValue) maxValue = num;
                }

                Console.WriteLine($"Smallest number: {minValue}");
                Console.WriteLine($"Largest number: {maxValue}");
            }
            else
            {
                Console.WriteLine("No numbers were entered.");
            }
        }

        static void RunChallenge2()
        {
            WeatherData wd = new WeatherData();

            wd.Scale = 'C';
            wd.Temperature = 25;
            wd.Humidity = 55;

            Console.WriteLine($"Initial: {wd.Temperature}{wd.Scale}, Humidity: {wd.Humidity}%");

            wd.Convert();
            Console.WriteLine($"After Convert: {wd.Temperature}{wd.Scale}, Humidity: {wd.Humidity}%");

            // Setting an invalid temperature just to test the error message
            wd.Temperature = 70; 
        }
    }
}
