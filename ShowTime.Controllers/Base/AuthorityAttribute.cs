using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.ComponentModel;
using System.Web.Mvc;
using ShowTime.DomainService.Objects;

namespace ShowTime.Controllers.Base
{
    /// <summary>
    /// 系统权限谁筛选
    /// </summary>
    public class AuthorityAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        public AuthorityAttribute(AccountType account = AccountType.Priv)
        {
            Do = account;
        }

        public AccountType Do
        {
            get;
            set;
        }
        public string MenuCode { get; set; }

        [DefaultValue(typeof(string), "")]
        public string ButtonCode { get; set; }

        private IAuthentication authent;
        public IAuthentication Authent
        {
            get { return authent ?? (authent = new Authentication()); }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Do != AccountType.NoLogin)
            {
                if (!Authent.IsLogin)
                    filterContext.Result = new RedirectResult("/account/login");
                else
                {
                    if (Do == AccountType.Priv)
                    {
                        var model = authent.CurrentUser;
                        if (model == null)
                            filterContext.Result = new RedirectResult("/account/login");
                        else
                        {
                            //权限验证
                            var priStr = model.MenuFunction;
                            var aName = filterContext.ActionDescriptor.ActionName.ToLower();
                            var cName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower();
                            var pri = priStr.FirstOrDefault(c =>c.Action!=null && c.Controller!=null && c.Action.ToLower().Equals(aName) && c.Controller.ToLower().Equals(cName));
                            if (pri == null)
                            {
                                filterContext.Result = new RedirectResult("/home/nopri");
                            }
                        }
                    }
                }
            }
            base.OnActionExecuting(filterContext);
        } 
    }

    public enum AccountType
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
        /// 需要权限验证
        /// </summary>
        Priv
    }
}