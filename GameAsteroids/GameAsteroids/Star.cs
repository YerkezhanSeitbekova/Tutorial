using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameBullets
{
    public class Star
    {
        public Point location;
        public int vx;
        public int vy;
        
        public Star()
        {
            Random rand = new Random();
            location = new Point(rand.Next(5, 500), rand.Next(5, 500));
            vx = rand.Next(5)-2;
            vy = rand.Next(5)-2;

        }
        public Star(int x)
        {
            Random rand = new Random();
            location = new Point(5, rand.Next(5, 500));
            vx = rand.Next(5) - 2;
            vy = rand.Next(5) - 2;

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
            
            Brush b = new SolidBrush(Color.White);
            g.FillEllipse(b, location.X, location.Y, 30, 30);

        }
       
    }
}
