/*----------------------------------------------------------------
// Copyright (C) 2010 北京新媒传信科技有限公司 版权所有。 
//
// 文件名：${ClassName}Controller.cs
// 文件功能描述：$Description
//
// 
// 创建标识：   $Author -- $CurrentTime 
//
// 添加标识：   
//
// 添加标识：   
//----------------------------------------------------------------*/
using System;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Collections.Generic;
using DMedia.Athena.Utils;
using DMedia.Taurus.${Module}.Builder;
using DMedia.Taurus.${Module}.Contract;
using DMedia.Taurus.${Module}.Controllers.DTO;
using DMedia.Athena.Components.Base;

namespace DMedia.Taurus.${Module}.Controllers
{
    public class ${ClassName}Controller : BaseController
    {
        #region 服务
        private I${ClassName}Service ${ClassName.ToLower()}Service;
        public I${ClassName}Service ${ClassName}Service
        {
            get { return ${ClassName.ToLower()}Service ?? (${ClassName.ToLower()}Service = ${ClassName}ServiceFactory.Create()); }
        }
        #endregion

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}