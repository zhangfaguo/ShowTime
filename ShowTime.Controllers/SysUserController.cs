using ShowTime.Controllers.Base;
using ShowTime.Controllers.DTO;
using ShowTime.Core.ViewModel;
using ShowTime.DomainService.Contracts;
using ShowTime.DomainService.Objects;
using ShowTime.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ShowTime.Controllers
{
    public class SysUserController : BaseController
    {
        #region 服务对象
        ISysUserService userPrivoder;

        IRoleService rolePrivoder;
        #endregion
        public SysUserController(ISysUserService _user, IRoleService _role)
        {
            userPrivoder = _user;
            rolePrivoder = _role;
        }

        public ActionResult Index()
        {
            var list = rolePrivoder.Find<object>();

            ViewBag.Role = new SelectList(list, "Id", "Name");
            return View();
        }

        [HttpPost]
        public JsonResult Index(SysUserDTO.UserIndexCondition model)
        {
            var list = userPrivoder.GetPage(model.Source);
            var query = from c in list
                        select new
                        {
                            id = c.Id,
                            Name = c.Name,
                            RealName = c.RealName,
                            Tel = c.Tel,
                            Statue = c.Statue.GetEnumDescription<UserStatue>(),
                            RoleId = c.UserRoles.Name
                        };

            return Json(new { total = model.RecordCount, rows = query });
        }


        public JsonResult Del(int id)
        {
            if (id == 0)
            {
                ModelState.AddModelError("9", "参数错误");
                return ModelState.GetFirstErrorMessageResult();
            }

            var iret = userPrivoder.Delete(c => c.Id == id);
            var js = new AjaxResult()
            {
                Success = true,
                Message = "操作成功！"
            };

            if (iret == 0)
            {
                js.Success = false;
                js.Message = "操作失败";
            }
            return Json(js);
        }

        public JsonResult GetOne(int id)
        {

            SysUserDTO.SaveModel model = new SysUserDTO.SaveModel();

            var entity = userPrivoder.Single(c => c.Id == id);
            if (entity != null)
            {
                model.Source = entity;

            }
            return Json(model,JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(SysUserDTO.SaveModel model)
        {
            if (!ModelState.IsValid)
                return ModelState.GetFirstErrorMessageResult();

            var iret = 0;
            if (model.Id == 0)
            {
                //验证用户名称是否存在
                if (userPrivoder.Count(c => c.Name == model.Name) > 0)
                {
                    ModelState.AddModelError("0", "用户名已存在");
                    return ModelState.GetFirstErrorMessageResult();
                }
                model.Source.Statue = (int)UserStatue.Success;
                var ioret = userPrivoder.Add(model.Source);
                iret = Convert.ToInt32(ioret.Id);
            }
            else
            {
                iret = userPrivoder.Update(c => c.Id == model.Id, c => new SysUserInfo()
                {
                    RealName = model.RealName,
                    Tel = model.Tel,
                    Statue = model.Statue,
                    RoleId = model.RoleId
                });
            }


            var js = new AjaxResult()
            {
                Success = true,
                Message = "操作成功！"
            };

            if (iret == 0)
            {
                js.Success = false;
                js.Message = "操作失败";
            }

            return Json(js);
        }

    
    }
}
