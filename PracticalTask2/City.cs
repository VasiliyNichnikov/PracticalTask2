using System;

namespace PracticalTask2
{
    public class City
    {
        public float PosX { get; }
        public float PosY { get; }

        private readonly string _name;

        public City(string name, float posX, float posY)
        {
            _name = name;
            PosX = posX;
            PosY = posY;
        }

        public float DistanceBetweenThisAndOtherCity(City otherCity)
        {
            float x2 = (float)Math.Pow(otherCity.PosX - this.PosX, 2);
            float y2 = (float)Math.Pow(otherCity.PosY - this.PosY, 2);

            return (float)Math.Sqrt(x2 + y2);
        }

        public override string ToString()
        {
            return $"<Name:{_name}-PosX:{PosX}-PosY:{PosY}>";
        }
    }
}