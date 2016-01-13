#region << 版 本 注 释 >>
/*
 * ========================================================================
 * Copyright(c) 2014-2015 重庆新媒农信科技有限公司, All Rights Reserved.
 * ========================================================================
 *  文件名：IAuthentication.cs
 *
 * 作者：张发国   时间：2014/12/26 11:00:29
 *
 * 版本：V1.0.0  
 *
 * 修改说明：
 *
 * ========================================================================
*/
#endregion
using ShowTime.DomainService.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowTime.Controllers.Base
{
    public interface IAuthentication
    {

        /// <summary>
        /// 是否登录
        /// </summary>
        bool IsLogin { get; }

        /// <summary>
        /// 写入角色权限信息
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="isPersistent"></param>

        void SetAuth(int uid, bool isPersistent);

        /// <summary>
        /// 登出
        /// </summary>
        void SignOut();


        /// <summary>
        /// 刷新session
        /// </summary>
        /// <param name="userId"></param>
        void RefreshSession(int userId);

        /// <summary>
        /// 
        /// </summary>
        SysUserInfo CurrentUser { get; }
    }
}
