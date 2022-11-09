using System;

namespace PracticalTask2
{
    public class Algorithm
    {
        private Random _random;
        private double _y = 0.99d;
        private const int NumberOfPermutations = 1000; // кол-во перестановок городов  в поисках оптимального решения 

        public Algorithm()
        {
            _random = new Random();
        }
        
        
        public City[] Run(City[] cities)
        {
            double t = 1d;
            float answer = Func(cities);
            
            for (int i = 0; i < NumberOfPermutations; i++)
            {
                t *= _y;
                // Копируем наш основной массив
                var copyCities = new City[cities.Length];
                cities.CopyTo(copyCities, 0);
                
                // У копии пытаемся найти другой путь
                RandomSwapCity(ref copyCities);
                
                // Получаем обновленный ответ
                var newAnswer = Func(copyCities);
                if (newAnswer > answer || RandomFromZeroToOne() < Math.Exp((newAnswer - answer) / t))
                {
                    cities = copyCities;
                    answer = newAnswer;
                }
            }

            return cities;
        }

        private void RandomSwapCity(ref City[] cities)
        {
            int indexCityOne = _random.Next(0, cities.Length);
            int indexCityTwo = _random.Next(0, cities.Length);

            (cities[indexCityOne], cities[indexCityTwo]) = (cities[indexCityTwo], cities[indexCityOne]);
        }

        private float RandomFromZeroToOne()
        {
            return (float)_random.NextDouble();
        }

        private float Func(City[] cities)
        {
            var distance = 0.0f;
            for (int i = 0; i < cities.Length; i++)
            {
                if(i + 1 >= cities.Length)
                {
                    break;
                }
                
                var currentCity = cities[i];
                var nextCity = cities[i + 1];

                var foundDistance = currentCity.DistanceBetweenThisAndOtherCity(nextCity);
                distance += foundDistance;
            }

            return distance;
        }
    }
}