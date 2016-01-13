using ShowTime.LockLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var h = LockManager.GetHelper<DbLockProvider>();
            h.Lock("keyy");

            for (var i = 0; i < 100; i++)
                Task.Factory.StartNew(Th);

            while (true)
            {
                var STR = Console.ReadLine();
                if (STR == "1")
                {
                    h.ReleaseLock("keyy");
                    break;
                }
                if (STR == "s")
                {
                    Task.Factory.StartNew(Th);
                    Task.Factory.StartNew(Th);
                    Task.Factory.StartNew(Th);
                    Task.Factory.StartNew(Th);
                    Task.Factory.StartNew(Th);
                    Task.Factory.StartNew(Th);
                    Task.Factory.StartNew(Th);
                    Task.Factory.StartNew(Th);
                }
                if (STR == "r")
                    h.ReleaseLock("keyy");
            }
        }


        public static void Th()
        {
            Console.WriteLine("thread START:" + System.Threading.Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine();
            var h = LockManager.GetHelper();
            if (h.Lock("keyy"))
                Console.WriteLine("Lock:" + System.Threading.Thread.CurrentThread.ManagedThreadId);
            else
                Console.WriteLine("Lock false:" + System.Threading.Thread.CurrentThread.ManagedThreadId);

        }
    }
}
