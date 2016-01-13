using ShowTime.Controllers.Base;
using ShowTime.DomainService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ShowTime.Controllers
{
    [Authority(AccountType.Login)]
    public class AjaxController : BaseController
    {
        IRoleService rolePrivoder;
        public AjaxController(IRoleService _role)
        {
            rolePrivoder = _role;
        }

    }
}
