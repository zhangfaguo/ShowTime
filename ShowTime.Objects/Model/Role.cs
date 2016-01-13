using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowTime.Objects.Model
{
    /// <summary>
    /// Role
    /// </summary>
    [Table("Role")]
    public class Role
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        [StringLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public int IsValid { get; set; }

        [ForeignKey("RoleId")]
        public  IList<RoleFunction> RoleFunction { get; set; }

    }
}