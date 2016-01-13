using System;
using System.Web.Mvc;
using System.Collections.Generic;
using  ${Module}.Core.ViewModel;
using  ${Module}.DomainService.Objects;

namespace ${Module}.Controllers.DTO
{
    public class ${ClassName}DTO 
    {
         public class SaveModel : BaseDTO<${ClassName}Info>
         {
            #foreach($column in $Table.Columns)

            ///<summary>
            ///$Helper.StringToSingleLine($column.Comments)
            ///</summary>
            public $Helper.SqlToCS($column.DataType) $column.Property
            {
                get{ 
                   return Source.$column.Property;
                }
                set{
                     Source.$column.Property=value;
                }
            }

            #end

        }
    }
}