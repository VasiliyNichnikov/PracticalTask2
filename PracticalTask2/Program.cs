using PracticalTask2.Utils;

namespace PracticalTask2
{
    static class Program
    {
        private static void Main(string[] args)
        {
            var annealingMethod = new Algorithm();
            var cities = DeserializeCities.Cities;

            var readyRoute = annealingMethod.Run(cities);
        }
    }
}