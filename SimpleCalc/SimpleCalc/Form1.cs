using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            calc = new CalcBrain();
        }
        bool clearTextbox = true;
        CalcBrain calc;
        private void digitbtn_click(object sender, EventArgs e)
        {
            
            Button btn = (Button)sender;
            if (clearTextbox)
            {
                textBox1.Text = "";
                clearTextbox = false;
            }
            textBox1.Text += btn.Text;

        }

        private void op_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            calc.op = btn.Text;
            calc.first = double.Parse(textBox1.Text);
            clearTextbox = true;


        }

        private void result_click(object sender, EventArgs e)
        {
            calc.second = double.Parse(textBox1.Text);
            calc.calculate();
            textBox1.Text = calc.result.ToString();

        }
    }
}
