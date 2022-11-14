using System;

namespace PracticalTask2
{
    public class Algorithm
    {
        private Random _random;
        private double _y = 0.1;
        private const int NumberOfPermutations = 10; // кол-во перестановок городов  в поисках оптимального решения 

        public Algorithm()
        {
            _random = new Random();
        }
        
        // todo нужно починить :)
        public City[] Run(City[] cities, double endT=0.00001d)
        {
            float answer = Func(cities);
            double initialT = 10d;
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
                
                // Console.WriteLine($"NewAnswer: {newAnswer}. Answer: {answer}. Exp: {RandomFromZeroToOne() < Math.Exp((newAnswer - answer) / t)}");
                // Console.WriteLine($"Value: {RandomFromZeroToOne()}. Exp: {}");
                var diff = newAnswer - answer;
                var exp = Math.Exp(-diff / t);
                Console.WriteLine($"Diff: {diff}. T: {t}. Exp: {exp}");
                if (newAnswer < answer || RandomFromZeroToOne() < Math.Exp((newAnswer - answer) / t))
                {
                    cities = copyCities;
                    answer = newAnswer;
                }

                t = initialT * _y / i;
                
                if (t < endT)
                {
                    break;
                }
            }

            return cities;
        }

        private void RandomSwapCity(ref City[] cities)
        {
            // todo поменять на инветирование между выбранными городами
            // todo статья: https://habr.com/ru/post/209610/
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