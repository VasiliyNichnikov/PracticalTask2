using PracticalTask2.Utils;

namespace PracticalTask2
{
    static class Program
    {
        private static void Main(string[] args)
        {
            var annealingMethod = new Algorithm(0.00001d, 10d);
            var cities = DeserializeCities.Cities;

            var readyRoute = annealingMethod.Run(new []
            {
                cities[0],
                cities[10],
                cities[67],
                cities[15],
                cities[100],
                cities[25]
            });
        }
    }
}