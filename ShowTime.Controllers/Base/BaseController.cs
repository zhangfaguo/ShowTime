using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace ShowTime.Controllers.Base
{
    public class BaseController : Controller
    {
        private IAuthentication authent;
        public IAuthentication Authent
        {
            get { return authent ?? (authent = new Authentication()); }
        }

    }
}
