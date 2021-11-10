namespace Mechanics
{
    public struct Coordinates
    {
        override public string ToString()
        {
            return x.ToString() + " " + y.ToString();
        }

        public int x, y;
        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Coordinates(Coordinates pair)
        {
            this.x = pair.x;
            this.y = pair.y;
        }

        static public Coordinates None;

        static public Coordinates right
        {
            get
            {
                return new Coordinates(0, 1);
            }
        }
        static public Coordinates left
        {
            get
            {
                return new Coordinates(0, -1);
            }
        }
        static public Coordinates up
        {
            get
            {
                return new Coordinates(-1, 0);
            }
        }
        static public Coordinates down
        {
            get
            {
                return new Coordinates(+1, 0);
            }
        }

        static public Coordinates operator +(Coordinates a, Coordinates b) => new Coordinates(a.x + b.x, a.y + b.y);
        static public Coordinates operator -(Coordinates a, Coordinates b) => new Coordinates(a.x - b.x, a.y - b.y);

        static public bool operator ==(Coordinates a, Coordinates b) => a.x == b.x && a.y == b.y;
        static public bool operator !=(Coordinates a, Coordinates b) => a.x != b.x || a.y != b.y;


        // Оператор умножения на любое число. Результат целое число. Уберается дробная часть
        static public Coordinates operator *(Coordinates a, float lambda) => new Coordinates((int)(a.x * lambda), (int)(a.y * lambda));
        static public Coordinates operator *(float lambda, Coordinates a) => new Coordinates((int)(a.x * lambda), (int)(a.y * lambda));

        // Оператор деления на любое число. Результат целое число. Уберается дробная часть
        static public Coordinates operator /(Coordinates a, float lambda) => new Coordinates((int)(a.x / lambda), (int)(a.y / lambda));
    }
}
