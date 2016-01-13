/*----------------------------------------------------------------
// Copyright (C) 2013 重庆新媒农信科技有限公司 版权所有。 
//
// 文件名：${ClassName}ServiceFactory.cs
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
using DMedia.Pandora.${Module}.Domain.Service;
using DMedia.Pandora.${Module}.Contract;
using DMedia.Phoenix.Core;

namespace DMedia.Pandora.${Module}.Builder
{
    public sealed class ${ClassName}ServiceFactory
    {
        public static I${ClassName}Service Create()
        {
            return new ${ClassName}Service(); 
        }

	
    }
}