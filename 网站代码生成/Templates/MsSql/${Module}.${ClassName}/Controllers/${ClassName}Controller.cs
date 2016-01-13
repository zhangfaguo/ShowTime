using System;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Collections.Generic;
using ${Module}.DomainService.Contracts;
using ${Module}.Controllers.DTO;

namespace ${Module}.Controllers
{
    public class ${ClassName}Controller : Controller
    {

        private I${ClassName}Service ${ClassName.ToLower()}Privoder;

        public ${ClassName}Controller(I${ClassName}Service _${ClassName.ToLower()})
        {
               ${ClassName.ToLower()}Privoder=_${ClassName.ToLower()};
        }

    }
}