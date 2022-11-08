using System;
using PracticalTask2.Utils;

namespace PracticalTask2
{
    static class Program
    {
        private static void Main(string[] args)
        {
            var cities = DeserializeCities.Cities;
            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }
        }
    }
}