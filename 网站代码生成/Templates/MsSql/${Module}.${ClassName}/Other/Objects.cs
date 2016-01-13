public class ${ClassName}Model : PageDTO<${ClassName}Condition>
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

public class ${ClassName}Condition:PageModel
{
#foreach($column in $Table.Columns)
  ///<summary>
  ///$Helper.StringToSingleLine($column.Comments)
  ///</summary>
  public $Helper.SqlToCS($column.DataType) $column.Property
  {
    get;set;
  }
#end
}


public IList<${ClassName}Info> Search(${ClassName}Info.${ClassName}Condition condition)
{
    var query = Query;
   #foreach($column in $Table.Columns)
      #if($Helper.SqlToCS($column.DataType)=="string")

        //$Helper.StringToSingleLine($column.Comments)
        if(!string.IsNullOrEmpty(condition.${column.Property}))
        {
         query = query.Where(c=>c.${column.Property}.Contains(condition.${column.Property}));
         query = query.Where(c=>c.${column.Property} == condition.${column.Property});
        }

      #else
        #if($Helper.SqlToCS($column.DataType)=="DateTime")

        //$Helper.StringToSingleLine($column.Comments)
        if(condition.${column.Property}>DateTime.MinValue)
        {
         query = query.Where(c=>c.${column.Property} > condition.${column.Property});
        }

        #else

        //$Helper.StringToSingleLine($column.Comments)
        if(condition.${column.Property} > 0)
        {
         query = query.Where(c=>c.${column.Property} == condition.${column.Property});
        }

        #end
     #end
  #end
query=query.OrderBy(c=>c.Id);
var list= query.Paging(condition);
return To<IList<${ClassName}Info>>(list.ToList());
}