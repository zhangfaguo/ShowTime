using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ShowTime.Core
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public LoginLeaveEnum Do { get; set; }

        public CustomAuthorizeAttribute(LoginLeaveEnum _do = LoginLeaveEnum.CheckAccess)
        {
            Do = _do;
        }

        /// <summary>
        /// 登录授权验证
        /// 此接口永远返回TRUE
        /// 如果验证不通过 直接返回httpContext设置Result属性
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            var isAjax = httpContext.Request.IsAjaxRequest();

            if (LoginLeaveEnum.NoLogin == this.Do)
                return true;

            return true;
        }
    }
}
