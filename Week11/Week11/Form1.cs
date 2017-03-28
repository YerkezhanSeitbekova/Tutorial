using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Week11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Black, 10);
            Brush b = new SolidBrush(Color.Blue);
            
            g.FillRectangle(b, 0,0,700, 500);
            g.DrawRectangle(p, 0, 0, 700, 500);
            Brush b2 = new SolidBrush(Color.White);
            int x = new Random().Next(0, 650);
            int y = new Random().Next(0, 450);
            g.FillEllipse(b2, x, y, 30, 30);
            
        }
    }
}
