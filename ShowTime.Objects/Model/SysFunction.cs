using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowTime.Objects.Model
{
    /// <summary>
    /// SysFunction
    /// </summary>
    [Table("SysFunction")]
    public class SysFunction
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [StringLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// 菜单样式
        /// </summary>
        [StringLength(66)]
        public string Style { get; set; }
        /// <summary>
        /// 菜单父级
        /// </summary>
        public int Parent { get; set; }
        /// <summary>
        /// 菜单区域
        /// </summary>
        [StringLength(33)]
        public string Area { get; set; }
        /// <summary>
        /// 菜单控件器
        /// </summary>
        [StringLength(33)]
        public string Controller { get; set; }
        /// <summary>
        /// 菜单响应
        /// </summary>
        [StringLength(33)]
        public string Action { get; set; }
        /// <summary>
        /// 是否是菜单
        /// </summary>
        public int IsMenu { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? Create { get; set; }
        /// <summary>
        /// 添加人
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public int IsValid { get; set; }

    }
}