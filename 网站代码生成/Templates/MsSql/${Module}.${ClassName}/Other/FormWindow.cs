
<div id="dlg" class="easyui-dialog" data-options="title: '详情', modal: true, resizable: true, width: 600, height:280,closed:true">
    <form id="ff">
        <table cellpadding="5" align="center" width="90%">
        
#foreach($column in $Table.Columns)
    <tr>
                <td>@Html.Label("${Helper.StringToSingleLine($column.Comments)}")</td>
                <td>@Html.TextBoxFor(m => m.$column.Property, new { @class = "easyui-textbox" })</td>
    </tr>
#end
        </table>
        <div id="dlg-buttons" style="text-align:center">
            <a href="javascript:;" class="easyui-linkbutton" data-options="iconCls:'icon-ok',plain:true" id="btnSubmit">提交</a>
            <a href="javascript:;" class="easyui-linkbutton" data-options="iconCls:'icon-cancel',plain:true" id="btnCancel" onclick="$('#dlg').dialog('close');">取消</a>
        </div>
        @Html.HiddenFor(m => m.Id)
    </form>
</div>


<script type="text/javascript">
    var ZBase = {
        DoSearch: function () {
            $('#dg').datagrid('load', $('#SearchForm').serializeJson());
        },

        add: function () {
            $("#ff").form("clear");
            $('#ff').form("load", { id: 0 });
            $("#dlg").dialog("open");
        },
        
        edit: function () {
            var row = $('#dg').datagrid("getSelected");

            if (!row) {
               jQuery.messager.alert('提示', "请选择要编辑的数据");
                return;
            }
            $("#ff").form("clear");
            $("#ff").form("load", "/company/get?id=" + row.id + "&_t=" + new Date().getTime());
            $("#dlg").dialog("open");
        },

        post: function () {
            jQuery.ajax({
                type: "post",
                dataType: "json",
                url: "/company/save",
                data: $('#ff').serializeJson(),
                beforeSend: function () {
                    jQuery.messager.progress();
                },
                success: function (result, status) {
                   jQuery.messager.progress('close');
                    if (result.Success) {
                        jQuery.messager.alert('Info', "操作成功");
                        $("#dg").datagrid("reload");
                        $("#dlg").dialog('close');
                    } else {
                       jQuery.messager.alert('Error', result.Message);
                    }
                },
                error: function () {
                    jQuery.messager.progress('close');
                    jQuery.messager.alert('Error', "操作失败");
                }
            });
        },
          del: function () {
            var row = $('#dg').datagrid("getSelected");

            if (!row) {
                jQuery.messager.alert('提示', "请选择要删除的数据");
                return;
            }
            var id = row.id;
            jQuery.messager.confirm('提示', '请确定要执行删除操作？', function (r) {
                if (r) {
                    jQuery.ajax({
                        type: "post",
                        dataType: "json",
                        url: "/company/del",
                        data: mvcParamMatch({ 'id': id }),
                        beforeSend: function () {
                           jQuery.messager.progress();
                        },
                        success: function (result, status) {
                            jQuery.messager.progress('close');
                            if (result.Success) {
                                jQuery.messager.alert('Info', "操作成功");
                                $("#dg").datagrid("reload");
                            } else {
                                jQuery.messager.alert('Error', result.Message);
                            }
                        },
                        error: function () {
                            jQuery.messager.progress('close');
                            jQuery.messager.alert('Error', "操作失败");
                        }
                    });
                }
            });
        },
        InitEvent: function () {
            $("#btnSearch").on("click", this.DoSearch);
            $("#btnEdit").on("click", this.edit);
            $("#btnRemove").on("click", this.del);
            $("#btnSubmit").on("click", this.post);
            $("#btnAdd").on("click", this.add);
        }
    };
    $(function () {
        ZBase.InitEvent();
    });
</script>
