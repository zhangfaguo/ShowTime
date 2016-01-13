using ShowTime.Data;
using ShowTime.Objects.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowTime.LockLab
{
    public class DbLockProvider : ILockProvider
    {
      
        /// <summary>
        /// 获取锁对象  
        /// 先判断锁对象是否否在  
        /// 如果不存在 则插入锁对象 
        /// 再获取锁对象
        /// </summary>
        /// <param name="uniKey"></param>
        /// <returns></returns>
        public LockObject GetLockItem(string uniKey)
        {
            ShowTimeDataContent ctx = new ShowTimeDataContent();
            LockClient lo = null;
            if (!ctx.Lock.Any(c => c.Key == uniKey))
            {
                try
                {
                    lo = new Objects.Model.LockClient()
                           {
                               ClinetCnt = 0,
                               Expire = DateTime.Now,
                               Key = uniKey,
                               Lock = 2,
                               Type = 1
                           };

                    ctx.Lock.Add(lo);
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                }
            }

            if (lo == null || lo.Id == 0)
            {
                lo = ctx.Lock.First(c => c.Key == uniKey);
            }

            LockObject obj = null;
            if (lo != null)
            {
                obj = new LockObject();
                obj.Id = lo.Id;
                obj.Key = lo.Key;
                obj.Lock = lo.Lock;
                obj.Type = lo.Type;
                obj.Expire = lo.Expire;
            }

            return obj;
        }

        /// <summary>
        /// 更新锁对象
        /// 这里是通过调用数据行锁进行更新 更新成功 则表示获取到锁
        /// </summary>
        /// <param name="lockItem"></param>
        /// <returns></returns>
        public bool UpLockItem(LockObject lockItem)
        {
            ShowTimeDataContent ctx = new ShowTimeDataContent();
            var item = ctx.Lock.Single(c => c.Key == lockItem.Key);

            if (item.Lock == 1 && item.Expire > DateTime.Now)
            {
                return false;
            }

            try
            {
                item.Expire = DateTime.Now.AddMinutes(5);

                item.Lock = 1;

                var rst = ctx.SaveChanges();

                return rst > 0;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// 释放锁
        /// </summary>
        /// <param name="uniKey"></param>
        public void ReleaseLock(string uniKey)
        {
            ShowTimeDataContent ctx = new ShowTimeDataContent();
            var item = ctx.Lock.Single(c => c.Key == uniKey);
            item.Lock = 2;
            ctx.SaveChanges();
        }
    }
}
