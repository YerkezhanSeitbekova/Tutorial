using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class SomeClass
    {
        public string SomeMethod(string n)
        {
            return n + " " + n;
        }
        public string SomeMethod(int n)
        {
            return n.ToString() + " " + n.ToString();
        }
    }
}
