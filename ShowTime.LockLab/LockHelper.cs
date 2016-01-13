using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowTime.LockLab
{
    public class LockHelper : ILockHelper
    {
        public LockHelper()
            : this(new DbLockProvider())
        {

        }

        public LockHelper(ILockProvider provider)
        {
            LockProvider = provider;
            TimeOut = 10 * 1000;
            SleepTime = 500;
        }

        public ILockProvider LockProvider
        {
            get;
            set;
        }

        public int TimeOut { get; set; }


        public int SleepTime { get; set; }

        public bool Lock(string uniKey)
        {
            try
            {
                var runCnt = 0;
                var tick = TimeOut / SleepTime;
                while (true)
                {

                    var item = this.LockProvider.GetLockItem(uniKey);

                    if (item.Lock == 2 || item.Expire < DateTime.Now)
                    {
                        //锁可更新状态
                        if (this.LockProvider.UpLockItem(item))
                        { break; }
                    }

                    //等待下次获取
                    System.Threading.Thread.Sleep(SleepTime);
                    runCnt++;
                    if (tick != 0 && runCnt > tick)
                        return false;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void ReleaseLock(string uniKey)
        {
            try
            {
                var item = this.LockProvider.GetLockItem(uniKey);
                if (item != null)
                {
                    if (item.Expire > DateTime.Now)
                        this.LockProvider.ReleaseLock(uniKey);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
