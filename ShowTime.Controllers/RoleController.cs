using ShowTime.Controllers.Base;
using ShowTime.Controllers.DTO;
using ShowTime.Core.ViewModel;
using ShowTime.DomainService.Contracts;
using ShowTime.DomainService.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ShowTime.Controllers
{
    public class RoleController : BaseController
    {
        IRoleService rolePrivoder;

        ISysFunctionService sysfunctionPrivoder;

        IRoleFunctionService roleFunctionPrivoder;

        public RoleController(IRoleService _role
            , ISysFunctionService _sysfunctionPrivoder
            , IRoleFunctionService _roleFunction)
        {
            rolePrivoder = _role;
            sysfunctionPrivoder = _sysfunctionPrivoder;
            roleFunctionPrivoder = _roleFunction;
        }


        public ActionResult Index()
        {

            return View();
        }

        public JsonResult IndexJson()
        {
            var list = rolePrivoder.GetAllRole();

            var query = from c in list
                        select new
                        {
                            id = c.Id,
                            name = c.Name,
                            codearr = c.RoleFunction.Select(b => b.FnId).ToArray()
                        };

            return Json(new { rows = query, total = list.Count() });
        }

        public JsonResult Save(RoleDTO.SaveModel model)
        {
            if (!ModelState.IsValid)
                return ModelState.GetAajaFirstErrorMessage();

            if (rolePrivoder.Count(c => c.Name == model.Name) > 0)
            {
                ModelState.AddModelError("Name", "角色名称已存在");
                return ModelState.GetAajaFirstErrorMessage();
            }

            rolePrivoder.Add(model.Source);

            return Json(new AjaxResult() { Success = true, Message = "操作成功" });
        }

        [Authority(AccountType.Login)]
        [HttpPost]
        public JsonResult FunIndexJson()
        {
            var list = this.sysfunctionPrivoder.Find<object>().ToList();

            IList<RoleDTO.Node> root = new List<RoleDTO.Node>();
            var first = list.Where(c => c.Parent == 0);
            foreach (var item in first)
            {
                MakeNodel(root, item, list);
            }

            return Json(root);
        }

        private void MakeNodel(IList<RoleDTO.Node> root, SysFunctionInfo currentSource
           , IList<SysFunctionInfo> allSource)
        {
            var node = new RoleDTO.Node()
            {
                id = currentSource.Id,
                text = currentSource.Name
            };
            root.Add(node);
            var childList = allSource.Where(c => c.Parent == currentSource.Id);
            if (childList.Count() > 0)
            {
                IList<RoleDTO.Node> child = new List<RoleDTO.Node>();
                node.children = child;
                foreach (var item in childList)
                {
                    MakeNodel(child, item, allSource);
                }
            }
        }

        [HttpPost]
        public JsonResult SavePri(int Id, IList<int> Ids)
        {
            var tag = roleFunctionPrivoder.BeginTransaction(() =>
             {
                 roleFunctionPrivoder.Delete(c => c.RoleId == Id);
                 foreach (var item in Ids)
                 {
                     roleFunctionPrivoder.Add(new RoleFunctionInfo()
                     {
                         FnId = item,
                         RoleId = Id
                     });
                 }
             });

            var js = new AjaxResult();
            if (tag)
            {
                js.Success = true;
                js.Message = "操作成功";
            }
            else
            {
                js.Success = false;
                js.Message = "操作失败";
            }
            return Json(js);
        }
    }
}
