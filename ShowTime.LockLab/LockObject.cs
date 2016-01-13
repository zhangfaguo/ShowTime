using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowTime.LockLab
{
    public class LockObject
    {
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// 锁类型  1
        /// </summary>
        public int Type
        {
            get;
            set;
        }

        /// <summary>
        /// 锁状态  1 锁  2未锁
        /// </summary>
        public int Lock
        {
            get;
            set;
        }

        /// <summary>
        /// 唯一标识
        /// </summary>
        public string Key
        {
            get;
            set;
        }

        /// <summary>
        /// 锁超时时间
        /// </summary>
        public DateTime Expire
        {
            get;
            set;
        }

        /// <summary>
        /// 客户端统计
        /// </summary>
        public int ClinetCnt
        {
            get;
            set;
        }
    }
}
