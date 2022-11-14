using System;

namespace PracticalTask2
{
    /// <summary>
    /// Алгоритм описан на сайте: https://habr.com/ru/post/209610/
    /// </summary>
    public class Algorithm
    {
        private Random _random;
        private double _y = 0.1;
        private const int NumberOfPermutations = 1000000; // кол-во перестановок городов  в поисках оптимального решения 

        private readonly double _minT;
        private readonly double _maxT;
        
        
        public Algorithm(double minT, double maxT)
        {
            _minT = minT;
            _maxT = maxT;
            _random = new Random();
        }
        
        // todo нужно починить :)
        public City[] Run(City[] cities)
        {
            float answer = Func(cities);
            double initialT = _maxT;
            var t = initialT;
            for (int i = 1; i < NumberOfPermutations + 1; i++)
            {
                // Копируем наш основной массив
                var copyCities = new City[cities.Length];
                cities.CopyTo(copyCities, 0);
                
                // У копии пытаемся найти другой путь
                RandomSwapCity(ref copyCities);
                
                // Получаем обновленный ответ
                var newAnswer = Func(copyCities);

                var diff = Math.Abs(newAnswer - answer);
                var exp = Math.Exp(-diff / t);
                
                if (newAnswer < answer || RandomFromZeroToOne() < exp)
                {
                    cities = copyCities;
                    answer = newAnswer;
                }

                t = initialT * _y / i;

                if (t <= _minT)
                {
                    break;
                }
            }

            return cities;
        }

        private void RandomSwapCity(ref City[] cities)
        {
            int indexCityStart = _random.Next(0, cities.Length);
            int indexCityEnd = _random.Next(0, cities.Length);

            var start = indexCityStart;
            var end = indexCityEnd;
            if (indexCityStart > indexCityEnd)
            {
                start = indexCityEnd;
                end = indexCityStart;
            }

            for (int i = start; i < end; i++)
            {
                if (i != end - 1)
                {
                    (cities[i], cities[end - i]) = (cities[end - i], cities[i]);
                }
            }
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