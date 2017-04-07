using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyPaint2017
{
    public partial class Form1 : Form
    {
        Shapes currentShape = Shapes.Free;
        Pen pen = new Pen(Color.Black, 30);
        Point start, current; // начальная точка и текущая точка
        Bitmap bmp; // image
        GraphicsPath gp = new GraphicsPath(); // нужен для рисования второго слоя
        Graphics g; // графика которая рисует на первом слое
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(pictureBox1.Image); // прикрепляем графику
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                start = e.Location;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                switch (currentShape)
                {
                    case Shapes.Free:
                        current = e.Location;
                        g.DrawLine(pen, start, current);
                        g.FillEllipse(new SolidBrush(pen.Color), current.X - pen.Width / 2, current.Y - pen.Width / 2, pen.Width, pen.Width);
                        start = current;
                        break;
                    case Shapes.Line:
                        current = e.Location;
                        gp.Reset();
                        gp.AddLine(start, current);
                        break;
                }
            }
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            g.DrawPath(pen, gp); // рисуется на 1 слое
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawPath(pen, gp); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentShape = Shapes.Free;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentShape = Shapes.Line;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
                button3.BackColor = colorDialog1.Color;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = (float)numericUpDown1.Value;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            pictureBox1.Image.Save("abs.jpg"); //saveFileDialog.filename
            
            g.Clear(Color.White);
            pictureBox1.Refresh();
        }
    }
    enum Shapes { Free, Line, Ellipse, Rectangle, Trangle };
}
