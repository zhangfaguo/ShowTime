using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowTime.Objects.Model
{
    [Table("T_LockObject")]
    public class LockClient
    {
        [Key]
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
        [Index(IsUnique=true)]
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

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
