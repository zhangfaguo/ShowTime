/*----------------------------------------------------------------
// Copyright (C) 2013 重庆新媒农信科技有限公司 版权所有。 
//
// 文件名：${ClassName}Info.cs
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

namespace DMedia.Pandora.${Module}.Contract
{
    /// <summary>
    /// ${ClassName}Info
    /// </summary>
    public class ${ClassName}Info
    {
#foreach($column in $Table.Columns)

        private $Helper.OracleToCS($column.DataType,$column.Length) _$column.Property;
        public bool ${column.Property}ValueChanged;
        /// <summary>
        /// $Helper.StringToSingleLine($column.Comments)
        /// </summary>
        public $Helper.OracleToCS($column.DataType,$column.Length) $column.Property
        {
            set
            {
		${column.Property}ValueChanged = true;
		_$column.Property = value;
            }
            get{return _$column.Property;}
        }
          
#end
    }
    /// <summary>
    /// ${ClassName}ExtensionResult
    /// </summary>
    public class ${ClassName}ExtensionResult
    {
        public IList<${ClassName}Info> ${ClassName}Collection { get; set; }
        public int Total{ get; set; }
    }
}