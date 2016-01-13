#region << 版 本 注 释 >>
/*
 * ========================================================================
 * Copyright(c) 2014-2015 重庆新媒农信科技有限公司, All Rights Reserved.
 * ========================================================================
 *  文件名：Authentication.cs
 *
 * 作者：张发国   时间：2014/12/26 11:02:17
 *
 * 版本：V1.0.0  
 *
 * 修改说明：
 *
 * ========================================================================
*/
#endregion
using ShowTime.Core;
using ShowTime.DomainService.Contracts;
using ShowTime.DomainService.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;


namespace ShowTime.Controllers.Base
{
    public class Authentication : IAuthentication
    {
        public const string UserSessionKey = "UserInfo";
        const string SessionRoleKey = "RoleKey";




        private ISysUserService usersService;
        public ISysUserService UserProvider
        {
            get { return usersService ?? (usersService =UnityContaint.Instance.Reloser<ISysUserService>()); }
        }

        public bool IsLogin
        {
            get
            {
                return HttpContext.Current.Request.IsAuthenticated;
            }
        }


        public void SetAuth(int uid, bool isPersistent)
        {
            ///将用户ID和角色写入Cookie
            FormsAuthentication.SetAuthCookie(uid.ToString(), isPersistent);

            HttpCookie authCookie = FormsAuthentication.GetAuthCookie(uid.ToString(), isPersistent);

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

            FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, uid.ToString());
            authCookie.Value = FormsAuthentication.Encrypt(newTicket);

            HttpContext.Current.Response.AddHeader("P3P", "CP=CAO PSA OUR");//解决ie js跨域调用

            HttpContext.Current.Response.Cookies.Add(authCookie);

            SetSession(uid);
        }

        /// <summary>
        ///保存用户状态
        /// </summary>
        /// <param name="uid"></param>
        private void SetSession(int uid)
        {

            if (HttpContext.Current.Session == null)
            {
                throw new ArgumentNullException("SessionState Failed");
            }
            SysUserInfo model = null;
            if (HttpContext.Current.Session[UserSessionKey] != null)
            {
                var sessionModel = HttpContext.Current.Session[UserSessionKey] as SysUserInfo;
                if (sessionModel.Id == uid)
                {
                    model = sessionModel;
                }
            }
            if (model == null)
            {
                model = UserProvider.GetUserInfoByUserId(uid);
            }

            HttpContext.Current.Session[UserSessionKey] = model;

        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.Session.Clear();
        }

        public void RefreshSession(int userId)
        {
            var info = UserProvider.GetUserInfoByUserId(userId);
            HttpContext.Current.Session[UserSessionKey] = info;
        }


        public SysUserInfo CurrentUser
        {
            get
            {
                if (!IsLogin)
                {
                    return null;
                }

                int uid;

                if (int.TryParse(HttpContext.Current.User.Identity.Name, out uid))
                {
                    if (HttpContext.Current.Session[UserSessionKey] == null)
                    {
                        SetSession(uid);
                    }

                    return HttpContext.Current.Session[UserSessionKey] as SysUserInfo;
                }
                return null;
            }
        }
    }
}
