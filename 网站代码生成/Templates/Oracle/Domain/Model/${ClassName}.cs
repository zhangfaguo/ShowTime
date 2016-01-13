using System;

namespace DMedia.Pandora.${Module}.Domain.Model
{
    /// <summary>
    /// ${ClassName}
    /// </summary>
    public class ${ClassName}
    {
#foreach($column in $Table.Columns)
        /// <summary>
        /// $Helper.StringToSingleLine($column.Comments)
        /// </summary>
        public virtual $Helper.OracleToCS($column.DataType,$column.Length) $column.Property { get; set; }
#end

    }
}