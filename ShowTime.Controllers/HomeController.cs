using ShowTime.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ShowTime.Controllers
{
    [Authority(AccountType.Login)]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.User = this.Authent.CurrentUser;
            return View();
        }
    }
}
