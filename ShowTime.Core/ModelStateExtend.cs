using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    public static class ModelStateExtend
    {

        public static string GetFirstErrorMessage(this ModelStateDictionary state)
        {
            var str = string.Empty;
            var err = state.Values.FirstOrDefault(c => c.Errors.Count > 0);
            if (err != null)
            {
                str = err.Errors[0].ErrorMessage;
            }
            return str;
        }

        public static JsonResult GetFirstErrorMessageResult(this  ModelStateDictionary state)
        {
            var str = state.GetFirstErrorMessage();
            return new JsonResult()
            {
                Data = new
                {
                    Success = false,
                    Message = str
                }
            };
        }
    }
}
