using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ${Module}.Objects.Model
{
    /// <summary>
    /// ${ClassName}
    /// </summary>
    [Table("${Table.Name}")]
    public class ${ClassName}
    {
#foreach($column in $Table.Columns)
        /// <summary>
        /// $Helper.StringToSingleLine($column.Comments)
        /// </summary>
        #if($column.IsPrimaryKey)
        [Key]
        #end
        #if($Helper.SqlToCS($column.DataType)=="string" && $column.Length>0)
         #set($b=$column.Length)
        #if($column.Length>30)
            #set($b=$b/3)
        #end
        [StringLength($b)]
        #end
        public  $Helper.SqlToCS($column.DataType) $column.Property { get; set; }
#end

    }
}