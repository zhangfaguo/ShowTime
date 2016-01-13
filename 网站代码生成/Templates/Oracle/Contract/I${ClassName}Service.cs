/*----------------------------------------------------------------
// Copyright (C) 2013 重庆新媒农信科技有限公司 版权所有。 
//
// 文件名：${ClassName}Service.cs
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DMedia.Phoenix.Core;
using DMedia.Pandora.${Module}.Contract;
using System.Data;

namespace DMedia.Pandora.${Module}.Contract
{
    public interface I${ClassName}Service : IService<${ClassName}Info>
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="info"></param>
        void Add(${ClassName}Info info);	

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="info"></param>
        void UpdateInfo(${ClassName}Info info);

        /// <summary>
        ///  分页
        /// </summary>
        /// <param name="kwyWord">搜索关键字</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        ${ClassName}ExtensionResult GetPageList(string kwyWord, int pageSize, int pageIndex);
    }
}
