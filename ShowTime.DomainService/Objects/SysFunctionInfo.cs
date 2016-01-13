using System;
using ShowTime.BaseServices;

namespace ShowTime.DomainService.Objects
{
     [Serializable]
    public class SysFunctionInfo
    {
                /// <summary>
        /// 
        /// </summary>
        public  int Id { get; set; }
                /// <summary>
        /// 菜单名称
        /// </summary>
        public  string Name { get; set; }
                /// <summary>
        /// 菜单样式
        /// </summary>
        public  string Style { get; set; }
                /// <summary>
        /// 菜单父级
        /// </summary>
        public  int Parent { get; set; }
                /// <summary>
        /// 菜单区域
        /// </summary>
        public  string Area { get; set; }
                /// <summary>
        /// 菜单控件器
        /// </summary>
        public  string Controller { get; set; }
                /// <summary>
        /// 菜单响应
        /// </summary>
        public  string Action { get; set; }
                /// <summary>
        /// 是否是菜单
        /// </summary>
        public  int IsMenu { get; set; }
                /// <summary>
        /// 添加时间
        /// </summary>
        public  DateTime? Create { get; set; }
                /// <summary>
        /// 添加人
        /// </summary>
        public  int UserId { get; set; }
                /// <summary>
        /// 是否可用
        /// </summary>
        public  int IsValid { get; set; }
        
    }
}
