using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.Generic;

namespace ShowTime.Objects.Model
{
    /// <summary>
    /// SysUser
    /// </summary>
    [Table("SysUser")]
    public class SysUser
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [StringLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        [StringLength(23)]
        public string Password { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        [StringLength(30)]
        public string RealName { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [StringLength(14)]
        public string Tel { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Statue { get; set; }

        /// <summary>
        /// 用户角色
        /// </summary>
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role UserRoles { get; set; }

        [ForeignKey("UserId")]
        public virtual IList<SysUserFunExtend> SysUserFunExtend { get; set; }

    }
}