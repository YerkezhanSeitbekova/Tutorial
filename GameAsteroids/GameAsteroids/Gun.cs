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
        public int vx;
        public int vy;
        
        public Gun()
        {
            location = new Point(250, 250);
            end = new Point(250, 230);
            vx = 0;
            vy = -2;

        }
        
        public void move()
        {
            location.X += vx;
            location.Y += vy;
            if (location.X < 2) location.X = 500;
            if (location.Y < 2) location.Y = 500;
            if (location.X > 500) location.X = 1;
            if (location.Y > 500) location.Y = 1;
        }
        public void draw(Graphics g)
        {
            Pen p = new Pen(Color.GreenYellow, 5);
           
            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            end.X = location.X + 20*vx/(int)Math.Sqrt(vx*vx+vy*vy);
            end.Y = location.Y + 20*vy/(int)Math.Sqrt(vx*vx+vy*vy);
            g.DrawLine(p, location, end);
           

        }
    }
}
