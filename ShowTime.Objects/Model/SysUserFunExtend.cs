using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowTime.Objects.Model
{
    /// <summary>
    /// SysUserFunExtend
    /// </summary>
    [Table("UserFunExtend")]
    public class SysUserFunExtend
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Key]
        [Column(Order = 0)]
        public int UserId { get; set; }
        /// <summary>
        /// 权限ID
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public int FnId { get; set; }

        [ForeignKey("FnId")]
        public SysFunction SysFunction { get; set; }

        [ForeignKey("UserId")]
        public SysUser User { get; set; }

    }
}