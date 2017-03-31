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
            if (e.KeyCode == Keys.Up)
            {
                if (!(gun.vx == 0 && gun.vy - 2 == 0) && gun.vy > -6) 
                gun.vy -= 2;
            } else if (e.KeyCode == Keys.Down)
            {
                if (!(gun.vx == 0 && gun.vy + 2 == 0) && gun.vy < 6) 
                gun.vy += 2;
            } else if (e.KeyCode == Keys.Right)
            {
                if (!(gun.vx + 2 == 0 && gun.vy == 0) && gun.vx < 6) 
                gun.vx += 2;
            } else if (e.KeyCode == Keys.Left)
            {
                if (!(gun.vx - 2 == 0 && gun.vy == 0) && gun.vx > -6) 
                gun.vx -= 2;
            }

            if (e.KeyCode == Keys.Enter)
            {
                Bullet Bullet = new Bullet(gun.end.X-15, gun.end.Y-15, gun.vx, gun.vy);
                bulls.Add(Bullet);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            stars.Add(new Star(1));
        }
    }
}
