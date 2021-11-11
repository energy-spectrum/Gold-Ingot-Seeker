namespace Mechanics
{
    [System.Serializable]
    public struct Coordinates
    {
        override public string ToString()
        {
            return x.ToString() + " " + y.ToString();
        }

        public int x, y, z;
        public Coordinates(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Coordinates(Coordinates coordinate)
        {
            this.x = coordinate.x;
            this.y = coordinate.y;
            this.z = coordinate.z;
        }

        static public Coordinates None;

        //static public Coordinates right
        //{
        //    get
        //    {
        //        return new Coordinates(0, 1, 0);
        //    }
        //}
        //static public Coordinates left
        //{
        //    get
        //    {
        //        return new Coordinates(0, -1, 0);
        //    }
        //}
        static public Coordinates up
        {
            get
            {
                return new Coordinates(0, 0, 1);
            }
        }
        static public Coordinates down
        {
            get
            {
                return new Coordinates(0, 0, -1);
            }
        }

        static public Coordinates operator +(Coordinates a, Coordinates b) => new Coordinates(a.x + b.x, a.y + b.y, a.z + b.z);
        static public Coordinates operator -(Coordinates a, Coordinates b) => new Coordinates(a.x - b.x, a.y - b.y, a.z - b.z);

        static public bool operator ==(Coordinates a, Coordinates b) => a.x == b.x && a.y == b.y && a.z == b.z;
        static public bool operator !=(Coordinates a, Coordinates b) => a.x != b.x || a.y != b.y || a.z != b.z;


        // Оператор умножения на любое число. Результат целое число. Уберается дробная часть
        static public Coordinates operator *(Coordinates a, float lambda) => new Coordinates((int)(a.x * lambda), (int)(a.y * lambda), (int)(a.z * lambda));
        static public Coordinates operator *(float lambda, Coordinates a) => new Coordinates((int)(a.x * lambda), (int)(a.y * lambda), (int)(a.z * lambda));

        // Оператор деления на любое число. Результат целое число. Уберается дробная часть
        static public Coordinates operator /(Coordinates a, float lambda) => new Coordinates((int)(a.x / lambda), (int)(a.y / lambda), (int)(a.y / lambda));
    }
}
