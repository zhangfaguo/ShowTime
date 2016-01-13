using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowTime.Core
{
    public class Program
    {
        public static void Main()
        {
            IList<B> list = new List<B>();
            for (var i = 0; i < 10000; i++)
            {
                list.Add(new B());
            }
            Stopwatch W = new Stopwatch();
            W.Start();
            foreach (var item in list)
            {
                item.MapTo<A>();
            }
            W.Stop();
            Console.WriteLine(W.ElapsedMilliseconds);
            Console.Read();
        }

        public class B
        {
            public string str1 { get; set; }
            public string str2 { get; set; }
            public string str3 { get; set; }
        }

        public class A
        {
            public string str1 { get; set; }
            public string str2 { get; set; }
            public string str3 { get; set; }
        }
    }
}
