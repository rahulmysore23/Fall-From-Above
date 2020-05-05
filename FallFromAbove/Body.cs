using System;

namespace FallFromAbove
{
    class Body
    {
        public int x, y;
        public string rep = "*";

        public Body(Random r)
        {
            x = r.Next(0, 100);
            y = r.Next(0, 3);
        }
    }
}
