using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;

namespace ShowTime.Objects.Model
{
    /// <summary>
    /// RoleFunction
    /// </summary>
    [Table("RoleFunction")]
    public class RoleFunction
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [Key]
        [Column(Order = 0)]
        public int RoleId { get; set; }
        /// <summary>
        /// 模块ID
        /// </summary>
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Function")]
        public int FnId { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public int IsValid { get; set; }


        public  SysFunction Function { get; set; }

    }
}