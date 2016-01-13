
 UnityContaint.Instance.RegistType<I${ClassName}Service, ${ClassName}Service>();
 
 CreateMap<${ClassName}, ${ClassName}Info>();

 public DbSet<${ClassName}> ${ClassName} { get; set; }

I${ClassName}Service ${ClassName.ToLower()}Privoder;

I${ClassName}Service _${ClassName.ToLower()}Privoder;
public I${ClassName}Service ${ClassName}Privoder
{
   get{
        if(_${ClassName.ToLower()}Privoder==null)
          _${ClassName.ToLower()}Privoder= UnityContaint.Instance.Reloser<I${ClassName}Service>();
        return _${ClassName.ToLower()}Privoder;
   } 
}
//Columns
#set($loopNum=1)
#foreach($column in $Table.Columns)$column.Name#if($loopNum<$Table.Columns.Count),#end#set($loopNum=$loopNum+1)#end

//描述
#set($loopNum=1)
#foreach($column in $Table.Columns)$Helper.StringToSingleLine($column.Comments)#if($loopNum<$Table.Columns.Count),#end#set($loopNum=$loopNum+1)#end


#foreach($column in $Table.Columns)
query.AddParameter("$column.Name", userInfo.$column.Property);
#set($loopNum=$loopNum+1)
#end

#set($loopNum=1)
#foreach($column in $Table.Columns)@$column.Name#if($loopNum<$Table.Columns.Count),#end#set($loopNum=$loopNum+1)#end

//实体赋值
${ClassName}Info model = new ${ClassName}Info();
#foreach($column in $Table.Columns) 
#if($Helper.OracleToCS($column.DataType,$column.Length)=="string")
model.$column.Property = "value";
#elseif($Helper.OracleToCS($column.DataType,$column.Length)=="DateTime" || $Helper.OracleToCS($column.DataType,$column.Length)=="Timestamp")
model.$column.Property =DateTime.Now;
#else
model.$column.Property =0;
#end
#end
//插入方法
using (SqlQuery query = new SqlQuery("$Table.Name"))
{
#foreach($column in $Table.Columns)
    query.AddParameter("$column.Name", model.$column.Property);
#end
     return query.Insert<int>();
}

#set($loopNum=1)
//查询
using (SqlQuery query = new SqlQuery("$Table.Name"))
{
    query.ResultFields = "#foreach($column in $Table.Columns)$column.Name#if($loopNum<$Table.Columns.Count),#end#set($loopNum=$loopNum+1)#end";
    query.Condition = "Id=@Id";
    query.AddParameter("Id", id);
    using (SqlDataReader reader = query.Reader())
    {
        if (reader.Read())
        {
            ${ClassName} model = new ${ClassName}();
#set($loopNum=0)
#foreach($column in $Table.Columns)
            model.$column.Property = reader.$Helper.SqlToReader($column.DataType)($loopNum);
#set($loopNum=$loopNum+1)
#end
            return model;
        }
    }
}

//更新操作
#set($loopNum=1)
result = ${ClassName}Service.Update(() => new ${ClassName}Info
{
#foreach($column in $Table.Columns)
#if($Helper.OracleToCS($column.DataType,$column.Length)=="string")
	$column.Property = "value" #if($loopNum<$Table.Columns.Count),#end

#else
	$column.Property =0 #if($loopNum<$Table.Columns.Count),#end

#end
#set($loopNum=$loopNum+1)
#end
},
model => model.Id == 100 );


//取得对象指定属性值
#set($loopNum=1)
${ClassName}Info item2 = ${ClassName}Service.GetById("Id", model =>
new object[] {#foreach($column in $Table.Columns)$column.Name#if($loopNum<$Table.Columns.Count),#end#set($loopNum=$loopNum+1)#end });   

//分页
var pagingInfo = new PagingInfo
{
	Conditions = "",
	Fileds = "#foreach($column in $Table.Columns)$column.Property,#end",
	GroupFields = "",
	KeyField = "ID",
	PageIndex = pageIndex,
	PageSize = pageSize,
	SortFields = "",
	TableName = "$Table.Name"
};
${ClassName}ExtensionResult result = new ${ClassName}ExtensionResult();
result.${ClassName}Collection = DataHelper.GetPagingData<${ClassName}Info>(pagingInfo, DbConntionType.OnlyRead);
result.PageIndex = pagingInfo.PageIndex;
result.PageCount = pagingInfo.PageCount;
return result;


private I${ClassName}Service ${ClassName.ToLower()}Service;
        public I${ClassName}Service ${ClassName}Service
        {
            get { return ${ClassName.ToLower()}Service ?? (${ClassName.ToLower()}Service = ${ClassName}ServiceFactory.Create()); }
        }

<!--${Description}-->
<register type="DMedia.Aries.${Module}.Contract.I${ClassName}Service,DMedia.Aries.${Module}.Contract" mapTo="DMedia.Aries.${Module}.Domain.Service.${ClassName}Service,DMedia.Aries.${Module}.Domain"></register>


ESBDictionary parameters = new ESBDictionary();
#foreach($column in $Table.Columns)
parameters.Add("$column.Property.ToLower()", this.$column.Property);
#end


DataTable dt = new DataTable();
#foreach($column in $Table.Columns)
dt.Columns.Add("$column.Name", typeof($Helper.SqlToCS($column.DataType)));
#end


 DataRow row = dt.NewRow();
#foreach($column in $Table.Columns)
row["$column.Name"] = item.$column.Property;
#end
dt.Rows.Add(row);