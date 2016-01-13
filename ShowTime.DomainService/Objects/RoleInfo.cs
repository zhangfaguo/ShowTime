using System;
using ShowTime.BaseServices;
using System.Collections.Generic;

namespace ShowTime.DomainService.Objects
{
    public class RoleInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public int IsValid { get; set; }


        public IList<RoleFunctionInfo> RoleFunction { get; set; }
    }
}
