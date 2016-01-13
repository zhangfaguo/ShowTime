using System;
using ${Module}.BaseServices;

namespace ${Module}.DomainService.Objects
{
    public class ${ClassName}Info
    {
        #foreach($column in $Table.Columns)
        /// <summary>
        /// $Helper.StringToSingleLine($column.Comments)
        /// </summary>
        public  $Helper.SqlToCS($column.DataType) $column.Property { get; set; }
        #end

    }
}
