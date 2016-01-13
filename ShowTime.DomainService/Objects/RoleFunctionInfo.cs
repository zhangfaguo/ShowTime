using System;
using ShowTime.BaseServices;

namespace ShowTime.DomainService.Objects
{
    public class RoleFunctionInfo
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 模块ID
        /// </summary>
        public int FnId { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public int IsValid { get; set; }

        public SysFunctionInfo Function { get; set; }

        public RoleInfo Role { get; set; }

    }
}
