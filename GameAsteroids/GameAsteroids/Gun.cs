using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace GameBullets
{
    public class Gun
    {
        public Point location;
        public Point end;
        public int direction;
        public int dx;
        public int dy;
        public Gun()
        {
            dx = dy = 0;
            location = new Point(250, 250);
            end = new Point(250, 230);
            direction = 90;

        }
        
        public void move()
        {
            location.X += dx;
            location.Y += dy;
            if (location.X < 2) location.X = 500;
            if (location.Y < 2) location.Y = 500;
            if (location.X > 500) location.X = 1;
            if (location.Y > 500) location.Y = 1;
        }
        public void draw(Graphics g)
        {
            Pen p = new Pen(Color.GreenYellow, 5);
           
            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            end.X = location.X + (int)(20.0*Math.Cos(direction * 3.14 / 180));
            end.Y = location.Y - (int)(20.0 * Math.Sin(direction * 3.14 / 180));
            g.DrawLine(p, location, end);
           

        }
    }
}
