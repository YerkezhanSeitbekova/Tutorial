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

namespace MyPaint
{
    public partial class Form1 : Form
    {
        Shape currentShape = Shape.Free;
        Graphics g;
        Pen p = new Pen(Color.Black, 2);
        Point startLocation;
        Point currentLocation;
        Point endLocation;
        GraphicsPath gp = new GraphicsPath();
        Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(pictureBox1.Image);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            p.Width = (float)numericUpDown1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentShape = Shape.Free;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentShape = Shape.Line;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                p.Color = cd.Color;
                button6.BackColor = cd.Color;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            startLocation = e.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            g.DrawPath(p, gp);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            switch (currentShape)
            {
                case Shape.Free:
                    g.DrawLine(p, startLocation, e.Location);
                    startLocation = e.Location;
                    break;
                case Shape.Line:
                    currentLocation = e.Location;
                    gp.Reset();
                    gp.AddLine(startLocation, currentLocation);
                    break;
            }
            pictureBox1.Refresh();

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawPath(p, gp);
        }
    }
    enum Shape { Free, Line, Ellipse, Rectangle, Triangle };
}
