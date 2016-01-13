using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    public static class ModelStateExtension
    {
        public static string FirstErrorMessage(this ModelStateDictionary source)
        {
            var error = source.Values.FirstOrDefault(c => c.Errors.Count > 0);
            if (error == null)
                return "";
            return error.Errors[0].ErrorMessage;
        }

        public static JsonResult GetAajaFirstErrorMessage(this ModelStateDictionary source)
        {
            var msg = FirstErrorMessage(source);
            return new JsonResult()
            {
                Data = new { Success = false, Message = msg },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

    }
}
