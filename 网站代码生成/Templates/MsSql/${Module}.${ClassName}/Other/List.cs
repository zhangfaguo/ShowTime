
<table id="dg" class="easyui-datagrid"
       data-options="url:'/users/index',method:'post',rownumbers:true,toolbar:'#tb',pagination:true,singleSelect:true,border:false,fit:true,fitColumns:true,idField:'id'">
    <thead>
        <tr>
            <th data-options="field:'ck',checkbox:true"></th>
#foreach($column in $Table.Columns)
 <th data-options="field:'${column.Property}'">$Helper.StringToSingleLine($column.Comments)</th>
#end
        </tr>
    </thead>
</table>

 @*  @Html.DropDownListFor(model => model.Statue, EnumExtension.GetEnumSelectViewList<ShowTime.Enum.UserStatue>(new SelectListItem() { Text = "请选择", Value = "0" }), new { @class = "easyui-combobox" })*@
<div id="tb">
    <form id="SearchForm">
#foreach($column in $Table.Columns)
 @Html.Label("${Helper.StringToSingleLine($column.Comments)}:")@Html.TextBoxFor(model => model.$column.Property, new { @class = "easyui-textbox" })
#end
        <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-search'" id="btnSearch">搜索</a>
    </form>
    <div>
        <a href="javascript:void(0)" class="easyui-linkbutton" id="btnAdd" data-options="iconCls:'icon-add',plain:true" onclick="ZBase.showWindow(0);">添加</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" id="btnEdit" data-options="iconCls:'icon-edit',plain:true">编辑</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" id="btnRemove" data-options="iconCls:'icon-reomve',plain:true">删除</a>
    </div>
</div>

<script type="text/javascript">
    var ZBase = {
        DoSearch: function () {
            $('#dg').datagrid('load', $('#SearchForm').serializeJson());
        },

        InitEvent: function () {
            $("#btnSearch").on("click", this.DoSearch);
        }
    };
    $(function () {
        ZBase.InitEvent();
    });
</script>


   [HttpPost]
        public JsonResult Index(SysUserDTO.UserIndexCondition model)
        {
            var list = userPrivoder.GetPage(model.Source);
            var query = from c in list
                        select new
                        {
                            id = c.Id,
                            #foreach($column in $Table.Columns)
${column.Property} = c.${column.Property},
#end
                        };

            return Json(new { total = model.RecordCount, rows = query });
        }