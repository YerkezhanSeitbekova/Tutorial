using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer_event(object sender, EventArgs e)
        {
            //label1.Text = DateTime.Now.ToString();
            label1.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + ":" + DateTime.Now.Millisecond;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            label1.Text = DateTime.Now.ToString();
        }
    }
}
