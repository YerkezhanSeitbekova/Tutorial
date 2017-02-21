using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadExample1
{
    class Program
    {
        public static int i = 0;
        public static void func()
        {
            while (i < 50 )
            {
                Thread.Sleep(10);
                i++;
                Console.WriteLine(Thread.CurrentThread.Name + i);
            }
           
        }

        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(func));
            t.Name = "Thread 1 ";
            t.Start();

            Thread t2 = new Thread(new ThreadStart(func));
            t2.Name = "Thread 2 ";
            t2.Start();
            Thread.Sleep(1000);
            t.Abort();
            t2.Abort();

            Console.ReadKey();

        }
    }
}
    
    
