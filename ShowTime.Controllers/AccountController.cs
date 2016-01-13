using ShowTime.Controllers.Base;
using ShowTime.Controllers.DTO;
using ShowTime.Core.ViewModel;
using ShowTime.DomainService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ShowTime.Controllers
{

    public class AccountController : BaseController
    {

        #region 服务对象
        ISysUserService userPrivoder;
        #endregion
        public AccountController(ISysUserService _user)
        {
            userPrivoder = _user;
        }

        [Authority(AccountType.NoLogin)]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Authority(AccountType.NoLogin)]
        public JsonResult Login(AccountDTO.LoginModel model)
        {
            if (!ModelState.IsValid)
                return ModelState.GetFirstErrorMessageResult();


            var js = new AjaxResult() { Success = true, Message = "登录成功" };
            var entity = userPrivoder.CheckLogin(model.Source);
            if (entity == null)
            {
                js.Success = false;
                js.Message = "用户名或密码错误";
            }
            else
            {
                if (entity.Name != model.LoginName || entity.Password != model.LoginPwd)
                {
                    js.Success = false;
                    js.Message = "用户名或密码错误";
                }
                else
                {
                    this.Authent.SetAuth(entity.Id, model.IsRemenberMe);
                }
            }
            return Json(js);
        }

        [Authority(AccountType.Login)]
        public ActionResult LoginOut()
        {
            this.Authent.SignOut();
            Session.Clear();
            return Redirect("~/");
        }
    }
}
