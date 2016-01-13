using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowTime.Core.ViewModel
{
    public class AjaxResult
    {
        /// <summary>
        /// 执行状态
        /// </summary>
        public bool Success { get; set; }

        public string Message { get; set; }

        public dynamic Data { get; set; }
    }
}
