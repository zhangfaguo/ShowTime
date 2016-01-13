using System;
using ShowTime.BaseServices;

namespace ShowTime.DomainService.Objects
{
     [Serializable]
    public class SysUserFunExtendInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 权限ID
        /// </summary>
        public int FnId { get; set; }


        public virtual SysUserInfo User { get; set; }


        public virtual SysFunctionInfo SysFunction { get; set; }
    }
}
