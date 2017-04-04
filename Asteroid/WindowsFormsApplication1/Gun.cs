using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  System.Drawing;

namespace WindowsFormsApplication1
{
    public class Gun
    {
        public Point location;
        public int alpha;
        public Gun()
        {
            location = new Point(450, 335);
            alpha = 90;
           
        }
        public void move(int _dx, int _dy)
        {
            location.X += _dx;
            location.Y += _dy;
        }
        public void draw(Graphics g)
        {
            Pen p = new Pen(Color.YellowGreen, 10);
            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            int x = location.X + (int)(30 * Math.Cos(alpha * 3.14 / 180));
            int y = location.Y - (int)(30 * Math.Sin(alpha * 3.14 / 180));
            Point end = new Point(x, y);
            g.DrawLine(p, location, end);
        }
    }
    
}
