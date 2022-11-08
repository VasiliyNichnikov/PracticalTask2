using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using PracticalTask2.Errors;

namespace PracticalTask2.Utils
{
    public static class DeserializeCities
    {
        /// <summary>
        /// 
        /// </summary>
        public static City[] Cities { get; }

        static DeserializeCities()
        {
            List<City> cities = new List<City>();
            string path = PathHandler.GetCitiesPath();
            using (StreamReader readText = new StreamReader(path))
            {
                string line;
                while ((line = readText.ReadLine()) != null)
                {
                    var cityData = line.Split();
                    var readyCity = ConvertToCity(cityData);

                    cities.Add(readyCity);
                }
            }

            Cities = cities.ToArray();
        }

        private static City ConvertToCity(string[] cityData)
        {
            if (cityData.Length < 3)
            {
                throw new DeserializeError("Incorrect City Data");
            }

            var lengthData = cityData.Length;
            var posX = cityData[lengthData - 2];
            var posY = cityData[lengthData - 1];
            var nameCity = new StringBuilder();

            RemoveExtraCharactersInNumbers(ref posX);
            RemoveExtraCharactersInNumbers(ref posY);

            for (int i = 0; i < lengthData - 2; i++)
            {
                if (i != 0)
                {
                    nameCity.Append(' ');
                }
                
                nameCity.Append(cityData[i]);
            }

            var posFloatX = float.Parse(posX, CultureInfo.InvariantCulture.NumberFormat);
            var posFloatY = float.Parse(posY, CultureInfo.InvariantCulture.NumberFormat);

            return new City(nameCity.ToString(), posFloatX, posFloatY);
        }

        /// <summary>
        /// Удаляем лишние символы у чисел
        /// К лишним символам относятся пробелы, запятые и точка с запятой
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static void RemoveExtraCharactersInNumbers(ref string text)
        {
            var charsToRemove = new[] { ",", ";", " " };
            foreach (var c in charsToRemove)
            {
                text = text.Replace(c, string.Empty);
            }
        }
    }
}