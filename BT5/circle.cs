using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT5
{
    class circle
    {
        public int radius = 50;
        public int x, y;
        public Color borderColor;

        public circle(int x, int y, Color borderColor)
        {
            this.x = x;
            this.y = y;
            this.borderColor = borderColor;
        }
    }
}
