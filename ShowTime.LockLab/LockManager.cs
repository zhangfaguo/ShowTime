using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowTime.LockLab
{
    public class LockManager
    {
        public static ILockHelper GetHelper()
        {
            return new LockHelper()
            {
                TimeOut = 6000
            };
        }

        public static ILockHelper GetHelper(int timeout)
        {
            return new LockHelper()
            {
                TimeOut = timeout
            };
        }


        public static ILockHelper GetHelper<T>(int timeout = 0) where T : ILockProvider, new()
        {
            return new LockHelper(new T())
            {
                TimeOut = timeout
            };
        }
    }
}
