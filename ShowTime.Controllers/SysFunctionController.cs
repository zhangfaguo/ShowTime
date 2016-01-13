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
    public class SysFunctionController : Controller
    {
        #region 服务接口

        ISysFunctionService sysfunctionPrivoder;
        #endregion

        public SysFunctionController(ISysFunctionService _sysfunctionPrivoder)
        {
            sysfunctionPrivoder = _sysfunctionPrivoder;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult IndexJson()
        {
            var list = this.sysfunctionPrivoder.Find<object>().ToList();

            IList<SysFunctionDTO.Node> root = new List<SysFunctionDTO.Node>();
            var first = list.Where(c => c.Parent == 0);
            foreach (var item in first)
            {
                MakeNodel(root, item, list);
            }

            return Json(root);
        }

        private void MakeNodel(IList<SysFunctionDTO.Node> root, SysFunctionInfo currentSource
           , IList<SysFunctionInfo> allSource)
        {
            var node = currentSource.MapTo<SysFunctionDTO.Node>();
            root.Add(node);
            var childList = allSource.Where(c => c.Parent == currentSource.Id);
            if (childList.Count() > 0)
            {
                IList<SysFunctionDTO.Node> child = new List<SysFunctionDTO.Node>();
                node.children = child;
                foreach (var item in childList)
                {
                    MakeNodel(child, item, allSource);
                }
            }
        }

        public JsonResult Save(SysFunctionDTO.SaveModel model)
        {
            AjaxResult js = new AjaxResult();
            if (!ModelState.IsValid)
            {
                return ModelState.GetFirstErrorMessageResult();
            }

            if (model.Id == 0)
            {
                model.Source.Create = DateTime.Now;
                model.Source.IsValid = 1;
                model.Source.UserId = 1;
                sysfunctionPrivoder.Add(model.Source);
            }
            else
            {
                sysfunctionPrivoder.Update(c => c.Id == model.Id, c => new SysFunctionInfo()
                {
                    Name = model.Name,
                    Style = model.Style,
                    Area = model.Area,
                    Action = model.Action,
                    Controller = model.Controller,
                    IsMenu = model.Source.IsMenu
                });
            }
            js.Success = true;
            js.Message = "操作成功";
            return Json(js);
        }

        public JsonResult GetOne(int id)
        {
            var entity = sysfunctionPrivoder.Single(c => c.Id == id);
            SysFunctionDTO.SaveModel model = new SysFunctionDTO.SaveModel()
            {
                Source = entity
            };
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Del(int id)
        {
            var cnt = sysfunctionPrivoder.Count(c => c.Parent == id);
            if (cnt > 0)
                return Json(new { Success = false, Message = "此菜单有子集，不能进行删除" });
            try
            {
                sysfunctionPrivoder.Delete(c => c.Id == id);
            }
            catch (Exception)
            {
                return Json(new AjaxResult() { Success = false, Message = "菜单关联使用中不能进行删除" });
            }
            return Json(new AjaxResult() { Success = true, Message = "操作成功" });
        }
    }
}
