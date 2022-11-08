namespace PracticalTask2
{
    public class City
    {
        private readonly string _name;
        private readonly float _posX;
        private readonly float _posY;
        
        public City(string name, float posX, float posY)
        {
            _name = name;
            _posX = posX;
            _posY = posY;
        }

        public override string ToString()
        {
            return $"<Name:{_name}-PosX:{_posX}-PosY:{_posY}>";
        }
    }
}