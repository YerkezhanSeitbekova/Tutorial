using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Star> stars;
        List<Asteroid> asteroids;
        List<Bullet> buls;
        Graphics g;
        Gun gun;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            g = this.CreateGraphics();
            stars = new List<Star>();
            asteroids = new List<Asteroid>();
            buls = new List<Bullet>();
            gun = new Gun();
            Star s = new Star(new Point(100,100), 2,-2);
            stars.Add(s);
            stars.Add(new Star(new Point(200, 200), -2, 2));
            asteroids.Add(new Asteroid(new Point(200, 400), -2, -2));
            asteroids.Add(new Asteroid(new Point(400, 400), 2, 2));
            asteroids.Add(new Asteroid(new Point(400, 200), 1, 1));
            Draw(g);
            timer1.Enabled = true;
        }
        private void Draw(Graphics g)
        {
            g.Clear(Color.Blue);
            Pen p = new Pen(Color.Black, 10);
            g.DrawRectangle(p, 0, 0, 880, 630);
            foreach (Star s in stars)
            {
                s.draw(g);
            }
            foreach (Asteroid a in asteroids)
            {
                a.draw(g);
            }
            foreach (Bullet b in buls)
            {
                b.draw(g);
            }
            gun.draw(g);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Star s in stars)
            {
                s.move();
            }
            foreach (Asteroid a in asteroids)
            {
                a.move();
            }
            foreach (Bullet b in buls)
            {
                b.move();
            }
            Draw(g);

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (gun.alpha <= 180) gun.alpha += 10;
                else gun.alpha -= 10;
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (gun.alpha <= 180) gun.alpha -= 10;
                else gun.alpha += 10;
            } else if (e.KeyCode==Keys.Enter)
            {
                
                int x = gun.location.X + (int)(15 * Math.Cos(gun.alpha * 3.14 / 180))-10;
                int y = gun.location.Y - (int)(15 * Math.Sin(gun.alpha * 3.14 / 180))-10;
                int vx = (int)(5 * Math.Cos(gun.alpha * 3.14 / 180));
                int vy = -(int)(5 * Math.Sin(gun.alpha * 3.14 / 180));
                buls.Add(new Bullet(new Point(x, y), vx, vy));
            }

            

        }
    }
}
