using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Bullet
    {
         public Point location;
        public int Vx;
        public int Vy;
        public Bullet(Point p, int _Vx, int _Vy)
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
            
        }
        public void draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.Green);
            g.FillRectangle(b, location.X, location.Y, 20, 20);
        }
    }
}
