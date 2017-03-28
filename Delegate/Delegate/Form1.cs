using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delegate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public delegate string DelegateName(string n);
        private void Form1_Load(object sender, EventArgs e)
        {
            DelegateName d;
            SomeClass s = new SomeClass();
            d = s.SomeMethod;
            button1.Text = d.Invoke("abcd");

        }
    }
}
