using System;
using ShowTime.BaseServices;
using System.Collections.Generic;
using ShowTime.Core.Model;

namespace ShowTime.DomainService.Objects
{
    [Serializable]
    public class SysUserInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Statue { get; set; }

        public int RoleId { get; set; }

        public virtual RoleInfo UserRoles { get; set; }


        public IList<SysUserFunExtendInfo> SysUserFunExtend { get; set; }

        public IList<SysFunctionInfo> Function { get; set; }

        public IList<SysFunctionInfo> MenuFunction { get; set; }

        public class LoginModel
        {
            /// <summary>
            /// 用户名
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// 登录密码
            /// </summary>
            public string Password { get; set; }

        }

        public class Search : PageModel
        {
            /// <summary>
            /// 
            /// </summary>
            public string RealName { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Tel { get; set; }
            /// <summary>
            /// 0 待审  1审核  3驳回  4  删除
            /// </summary>
            public int Statue { get; set; }
        }

    }

}
