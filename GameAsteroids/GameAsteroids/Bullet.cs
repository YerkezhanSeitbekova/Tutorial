using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameAsteroids
{
    public class Bullet
    {
        public Point location;
        private int vx;
        private int vy;
        public Bullet(int x, int y, int dx, int dy)
        {
            location = new Point(x, y);
            vx = dx;
            vy = dy;
        }
        public Bullet()
        {
            Random rand = new Random();
            location = new Point(rand.Next(5, 500), rand.Next(5, 500));
            vx = rand.Next(5)-2;
            vy = rand.Next(5)-2;

        }
        public Bullet(int x, int y)
        {
            Random rand = new Random();
            location = new Point(x, y);
            vx = rand.Next(5) - 2;
            vy = rand.Next(5) - 2;

        }
        public void move()
        {
            location.X += vx;
            location.Y += vy;
        }
        public void draw(Graphics g)
        {
            PointF[] pts = StarPoints(5, new Rectangle(location, new Size(30,30)));
            Brush b = new SolidBrush(Color.Red);
            g.FillPolygon(b, pts);

        }
        public PointF[] StarPoints(int num_points, Rectangle bounds)
        {
            // Make room for the points.
            PointF[] pts = new PointF[num_points];

            double rx = bounds.Width / 2;
            double ry = bounds.Height / 2;
            double cx = bounds.X + rx;
            double cy = bounds.Y + ry;

            // Start at the top.
            double theta = -Math.PI / 2;
            double dtheta = 4 * Math.PI / num_points;
            for (int i = 0; i < num_points; i++)
            {
                pts[i] = new PointF(
                    (float)(cx + rx * Math.Cos(theta)),
                    (float)(cy + ry * Math.Sin(theta)));
                theta += dtheta;
            }

            return pts;
        }
    }
}
