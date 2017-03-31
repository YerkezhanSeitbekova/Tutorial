using GameAsteroids;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameBullets
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Star> stars;
        Gun gun;
        List<Bullet> bulls;
        Graphics g; 
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            bulls = new List<Bullet>();
            stars = new List<Star>();
            g = this.CreateGraphics();
            g.Clear(Color.Blue);
            stars.Add(new Star());
            gun = new Gun();
            gun.draw(g);
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.Blue);
            foreach (Star s in stars)
            {
                s.move();
                s.draw(g);
            }
            gun.draw(g);
            if (bulls.Count != 0)
            {
                foreach (Bullet bul in bulls)
                {
                    bul.move();
                    if (bul.location.X > 5 || bul.location.X < 500 || bul.location.Y > 5 || bul.location.Y < 500)
                        bul.draw(g);
                    else bulls.Remove(bul);
                }
            }
           
        }

       
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            gun.direction = (gun.direction + 360) % 360;
            if (e.KeyCode == Keys.Up)
            {
                if (gun.direction> 270 || gun.direction< 90)
                    gun.direction += 10;
                else
                    gun.direction -= 10;
            } else if (e.KeyCode == Keys.Down)
            {
                if (gun.direction> 270 || gun.direction< 90)
                    gun.direction -= 10;
                else
                    gun.direction += 10;
            } else if (e.KeyCode == Keys.Right)
            {
                if (gun.direction < 180)
                    gun.direction -= 10;
                else
                    gun.direction += 10;
            } else if (e.KeyCode == Keys.Left)
            {
                if ( gun.direction < 180)
                    gun.direction += 10;
                else
                    gun.direction -= 10;
            }

            if (e.KeyCode == Keys.Enter)
            {
                int vx = (int)(5.0*Math.Cos(gun.direction * 3.14 / 180));
                int vy = -(int)(5.0*Math.Sin(gun.direction * 3.14 / 180));
                Bullet b = new Bullet(gun.end.X-15, gun.end.Y-15, vx , vy);
                bulls.Add(b);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            stars.Add(new Star(1));
        }
    }
}
