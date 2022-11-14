using System;
using System.IO;

namespace PracticalTask2.Utils
{
    public static class PathHandler
    {
        /// <summary>
        /// Возвращает путь до файла с данными (Json файл)
        /// </summary>
        /// <returns></returns>
        public static string GetCitiesPath()
        {
            var rootProject = GetRootProject();
            var combinedPath = Path.Combine(rootProject, @"Static\cities.txt");
            return combinedPath;
        }
        
        private static string GetRootProject()
        {
            var path = Directory.GetCurrentDirectory();
            return Directory.GetParent(path)?.Parent?.Parent?.FullName;
        }
    }
}