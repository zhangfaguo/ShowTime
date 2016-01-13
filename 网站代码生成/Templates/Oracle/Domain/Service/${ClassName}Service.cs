/*----------------------------------------------------------------
// Copyright (C) 2013 重庆新媒农信科技有限公司 版权所有。 
//
// 文件名：${ClassName}Controller.cs
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
using System.Data;
using System.Text;
using System.Configuration;
using DMedia.Pandora.${Module}.Contract;
using DMedia.Pandora.${Module}.Domain.Model;
using DMedia.Phoenix.Core;
using System.Data.OracleClient;

namespace DMedia.Pandora.${Module}.Domain.Service
{
    public class ${ClassName}Service : Service<${ClassName}Info, ${ClassName}>, I${ClassName}Service 
    {

        #region 添加/修改方法  Add by thp
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="info"></param>
        public void Add(${ClassName}Info info)
        {
            using (DMedia.Phoenix.Data.DataAdapter da = DMedia.Phoenix.Data.Helper.CreateDataAdapter())
            {
                string sql = @"insert into $Table.Name
                                  (#set($i=1)#foreach($column in $Table.Columns)${column.Name}#if($i<$Table.Columns.Count),#end#set($i=$i+1)#end)
                                values
                                  (#set($i=1)#foreach($column in $Table.Columns)#if(${column.Name}=="ID")${Table.Name}_0.nextval#else:v_$column.Property#end#if($i<$Table.Columns.Count),#end#set($i=$i+1)#end)";
#foreach($column in $Table.Columns)
#if(${column.Name}!="ID")

#if($column.DataType=="CLOB")
                OracleParameter op$column.Property = new OracleParameter("v_$column.Property", OracleType.Clob);
                op.Direction = ParameterDirection.Input;
                op.Size = System.Text.Encoding.Unicode.GetByteCount(info.$column.Property);
                op.Value = info.$column.Property;
                da.Parameters.Add(op$column.Property);
#else
                da.Parameters.Add(da.CreateParameter("v_$column.Property", info.$column.Property));
#end
#end
#end               
                da.CommandText = sql;
                da.CommandType = CommandType.Text;
                da.ExecuteNonQuery();
            }
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="info"></param>
        public void UpdateInfo(${ClassName}Info info)
        {
            using (DMedia.Phoenix.Data.DataAdapter da = DMedia.Phoenix.Data.Helper.CreateDataAdapter())
            {
                string table = " $Table.Name a ";
                string file = "";
		string where = "";
                string sql = "";
#set($i=1)
#foreach($column in $Table.Columns)
#if(${column.Name}!="ID")
                if (info.${column.Property}ValueChanged)
		{
#if($i<$Table.Columns.Count)
                    file += "a.${column.Name}=:v_${column.Property},";
#else
                    file += "a.${column.Name}=:v_$column.Property";
#end

#if($column.DataType=="CLOB")
                OracleParameter op$column.Property = new OracleParameter("v_$column.Property", OracleType.Clob);
                op.Direction = ParameterDirection.Input;
                op.Size = System.Text.Encoding.Unicode.GetByteCount(info.$column.Property);
                op.Value = info.$column.Property;
                da.Parameters.Add(op$column.Property);
#else
                da.Parameters.Add(da.CreateParameter("v_$column.Property", info.$column.Property));
#end


		}                                      
#end
#set($i=$i+1)
#end

#foreach($column in $Table.Columns)
#if(${column.Name}=="ID")
                if (info.${column.Property}ValueChanged)
		{
                    where = " where a.${column.Name}=:v_$column.Property";
                    da.Parameters.Add(da.CreateParameter("v_$column.Property", info.$column.Property));
		}  
#end
#end                               
		if(!string.IsNullOrEmpty(where)&&!string.IsNullOrEmpty(file))
		{    
                    sql="update " + table + file + where;        
                    da.CommandText = sql;
                    da.CommandType = CommandType.Text;
                    da.ExecuteNonQuery();
		}
            }
        }
        #endregion

	/// <summary>
        ///  分页
        /// </summary>
        /// <param name="kwyWord">搜索关键字</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public ${ClassName}ExtensionResult GetPageList(string kwyWord, int pageSize, int pageIndex)
        {
            IList<${ClassName}Info> list = new List<${ClassName}Info>();
            int suncount = 0;
            ${ClassName}ExtensionResult result = new ${ClassName}ExtensionResult();
            using (DMedia.Phoenix.Data.DataAdapter da = DMedia.Phoenix.Data.Helper.CreateDataAdapter())
            {

                string table = "$Table.Name a";
                string file = @"#foreach($column in $Table.Columns)#if(${column.Name}=="ID")row_number() OVER(ORDER BY a.${column.Name} DESC) AS RowNumber#end#end
#set($i=0)
#foreach($column in $Table.Columns)
#set($i=$i+1)
#if(${column.Name}!="ID")
				
				,a.${column.Name}#if($i==$Table.Columns.Count)";#end
#end
#end
			
                string where = "#foreach($column in $Table.Columns)#if(${column.Name}=="AuditState") where a.${column.Name}=1 #end#end";
                int startPage = pageSize * (pageIndex - 1) + 1;
                int endPage = pageSize * pageIndex;
                if (!string.IsNullOrEmpty(kwyWord))
                {
                    where += " and (a.productname like '%'||:v_kwyWord||'%' or a.other like '%'||:v_kwyWord||'%' or b.name like '%'||:v_kwyWord||'%' or b.level1name like '%'||:v_kwyWord||'%' or b.level2name like '%'||:v_kwyWord||'%')";
                    da.Parameters.Add(da.CreateParameter("v_kwyWord", kwyWord));                    
                }
                
                DataTable dt = new DataTable();
                da.CommandText = "select T.* from (select " + file + " from " + table + where + " order by a.id desc) T where T.RowNumber BETWEEN " + startPage + " and " + endPage;
               
                da.Fill(dt);
                list = DMedia.Phoenix.Data.Helper.GetObjects<${ClassName}Info>(dt);

                da.CommandText = "select count(0) from " + table + where;
                suncount = Convert.ToInt32(da.ExecuteScalar());
            }

            result.${ClassName}Collection = list;
            result.Total = suncount;
            return result;
        }
		
    }
}
