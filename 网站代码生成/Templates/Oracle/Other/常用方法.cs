//Columns
#set($loopNum=1)
#foreach($column in $Table.Columns)$column.Name#if($loopNum<$Table.Columns.Count),#end#set($loopNum=$loopNum+1)#end

#set($loopNum=1)
#foreach($column in $Table.Columns)@$column.Name#if($loopNum<$Table.Columns.Count),#end#set($loopNum=$loopNum+1)#end

//插入方法一
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
var result = ${ClassName}Service.Insert(model);

//插入方法二
#set($loopNum=1)
result = ${ClassName}Service.Insert(() => new ${ClassName}Info
{
#foreach($column in $Table.Columns)
#if($Helper.OracleToCS($column.DataType,$column.Length)=="string")
	$column.Property = "value" #if($loopNum<$Table.Columns.Count),#end

#else
	$column.Property =0 #if($loopNum<$Table.Columns.Count),#end

#end
#set($loopNum=$loopNum+1)
#end
});

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
