using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public class Star
    {
        public Point location;
        public int Vx;
        public int Vy;
        public Star(Point p, int _Vx, int _Vy)
        {
            location = new Point();
            location = p;
            Vx = _Vx;
            Vy = _Vy;

        }
        public void move()
        {
            location.X += Vx;
            location.Y += Vy;
            if (location.X < 10) location.X = 890;
            if (location.X > 890) location.X = 10;
            if (location.Y > 660) location.Y = 10;
            if (location.Y < 10) location.Y = 660;
        }
        public void draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.White);
            g.FillEllipse(b, location.X, location.Y, 25, 25);
        }
    }
}
