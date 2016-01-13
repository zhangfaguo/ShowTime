using ShowTime.Core.Model;
using ShowTime.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ShowTime.Core.Extension
{
    public static class HtmlHelperExtension
    {

        /// <summary>  
        /// 分页Pager显示  
        /// </summary>   
        /// <param name="html"></param>  
        /// <param name="currentPageStr">标识当前页码的QueryStringKey</param>   
        /// <param name="pageSize">每页显示</param>  
        /// <param name="totalCount">总数据量</param>  
        /// <returns></returns> 
        public static MvcHtmlString Pager<T>(this HtmlHelper html, PageDTO<T> page)
            where T : PageModel, new()
        {

            var currentPageStr = "page";
            var pageSize = page.Size.Value;
            var totalCount = page.RecordCount;
            var queryString = html.ViewContext.HttpContext.Request.QueryString;
            int currentPage = page.Page.Value; //当前页  
            var totalPages = page.PageCount; //总页数  

            var dict = new System.Web.Routing.RouteValueDictionary(html.ViewContext.RouteData.Values);

            var output = new StringBuilder();
            if (!string.IsNullOrEmpty(queryString[currentPageStr]))
            {
                //与相应的QueryString绑定 
                foreach (string key in queryString.Keys)
                    if (queryString[key] != null && !string.IsNullOrEmpty(key))
                        dict[key] = queryString[key];
                int.TryParse(queryString[currentPageStr], out currentPage);
            }
            else
            {
                //获取 ～/Page/{page number} 的页号参数
                if (dict.ContainsKey(currentPageStr))
                    int.TryParse(dict[currentPageStr].ToString(), out currentPage);
            }

            //保留查询字符到下一页
            foreach (string key in queryString.Keys)
                dict[key] = queryString[key];

            //如果有需要，保留表单值到下一页 (我暂时不需要， 所以注释掉)
            //var formValue = html.ViewContext.HttpContext.Request.Form;
            //foreach (string key in formValue.Keys)
            //    if (formValue[key] != null && !string.IsNullOrEmpty(key))
            //        dict[key] = formValue[key]; 

            if (currentPage <= 0) currentPage = 1;

            if (totalPages > 1)
            {
                output.AppendLine("<div class=\"row DTTTFooter\">");
                output.AppendLine("<div class=\"col-sm-6\">");
                var start = 0;
                start = (currentPage - 1) * pageSize + 1;
                var end = start + pageSize;
                if (end > totalCount)
                    end = totalCount;
                output.AppendFormat("<div class=\"dataTables_info\">Showing {1} to {2} of {0} entries</div>", totalCount, start, end);
                output.AppendLine("</div>");
                output.AppendLine("<div class=\"col-sm-6\"><div class=\"dataTables_paginate paging_bootstrap\" id=\"simpledatatable_paginate\"> <ul class=\"pagination\">");
                //if (currentPage != 1)
                //{
                //    //处理首页连接  
                //    dict[currentPageStr] = 1;
                //    output.AppendFormat("{0} ", html.RouteLink("首页", dict));
                //}

                if (currentPage > 1)
                {
                    //处理上一页的连接  
                    dict[currentPageStr] = currentPage - 1;
                    output.Append("<li class=\"prev disabled\">");
                    output.Append(html.RouteLink("Prev", dict));
                    output.Append("</li>");
                }
                else
                {
                    output.Append("<li class=\"prev disabled\"><a href=\"javascript:;\">Prev</a></li>");
                }

                int currint = 3;
                for (int i = 0; i <= 6; i++)
                {
                    //一共最多显示10个页码，前面5个，后面5个  
                    if ((currentPage + i - currint) >= 1 && (currentPage + i - currint) <= totalPages)
                        if (currint == i)
                        {
                            //当前页处理  
                            output.AppendFormat(" <li class=\"active\"><a href=\"javascript:;\">{0}</a></li>", currentPage);
                        }
                        else
                        {
                            //一般页处理 
                            dict[currentPageStr] = currentPage + i - currint;
                            output.Append("<li>");
                            output.Append(html.RouteLink((currentPage + i - currint).ToString(), dict));
                            output.Append("</li>");
                        }
                    output.Append(" ");
                }

                if (currentPage < totalPages)
                {
                    //处理下一页的链接 
                    dict[currentPageStr] = currentPage + 1;
                    output.Append("<li class=\"next\">");
                    output.Append(html.RouteLink("Next", dict));
                    output.Append("</li>");
                }
                else
                {
                    output.Append("<li class=\"next disabled\"><a href=\"javascript:;\">Next</a></li>");
                }

                output.Append("</ul></div></div></div>");
            }

            //     output.AppendFormat("{0} / {1}", currentPage, totalPages);//这个统计加不加都行

            return new MvcHtmlString(output.ToString());
        }

        /// <summary>
        /// 自定义后台ModelState错误提示信息输出
        /// 可以输入后台验证框架验证数据 或手动使用ModelState.AddModelError("OrderID", "身份证号码错误");
        /// 注意Key值是当前模型的属性名称
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="runJsName"></param>
        /// <returns></returns>
        public static MvcHtmlString Errors(this HtmlHelper htmlHelper, string runJsName = "showError")
        {
            if (htmlHelper == null)
            {
                throw new ArgumentNullException("htmlHelper");
            }
            if (htmlHelper.ViewData.ModelState.IsValid)
            {
                return null;
            }

            #region MyRegion
            StringBuilder sb = new StringBuilder();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            var list = htmlHelper.ViewData.ModelState.Values.Where(c => c.Errors.Count > 0);
            foreach (var state in htmlHelper.ViewData.ModelState)
            {
                var key = state.Key;
                if (state.Value.Errors.Count > 0 && !string.IsNullOrEmpty(state.Value.Errors[0].ErrorMessage))
                {
                    dict.Add(key, state.Value.Errors[0].ErrorMessage);
                }
            }
            #endregion

            if (dict.Count == 0)
                return null;

            sb.AppendLine("<script type='text/javascript'>$(function(){");
            foreach (var item in dict)
            {
                sb.AppendLine(string.Format("{0}(\"{1}\",\"{2}\");", runJsName, item.Key, item.Value));
            }
            sb.AppendLine("});</script>");

            return new MvcHtmlString(sb.ToString());
        }

        /// <summary>
        /// 后台需要使用ViewBag.AlertMessage传值  或在基类实现Alert 对ViewBagf进行传值
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="runJsNume"></param>
        /// <returns></returns>
        public static MvcHtmlString Alert(this HtmlHelper htmlHelper, string runJsNume = "alert")
        {
            var str = htmlHelper.ViewBag.AlertMessage;
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<script type='text/javascript'>$(function(){");
            sb.AppendLine(string.Format("{0}(\"{1}\");", runJsNume, str));
            sb.AppendLine("});</script>");

            return new MvcHtmlString(sb.ToString());
        }
    }

}
