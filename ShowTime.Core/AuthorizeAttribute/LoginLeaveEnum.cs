using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowTime.Core
{
    public enum LoginLeaveEnum
    {
        /// <summary>
        /// 不需要登录
        /// </summary>
        NoLogin,
        /// <summary>
        /// 需要登录
        /// </summary>
        Login,
        /// <summary>
        /// 需要检查权限
        /// </summary>
        CheckAccess
    }
}
