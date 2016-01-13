using ShowTime.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace System
{
    public static class QueryPageExtension
    {
        public static IQueryable<T> Paging<T>(this  IQueryable<T> query, PageModel page)
        {
            page.RecordCount = query.Count();

            if (page.PageSize == 0)
                page.PageSize = 10;

            page.PageCount = (page.RecordCount + page.PageSize - 1) / page.PageSize;

            if (page.PageIndex < 1)
                page.PageIndex = 1;

            if (page.PageIndex > page.PageCount && page.PageCount != 0)
                page.PageIndex = page.PageCount;

            var takeRecord = (page.PageIndex - 1) * page.PageSize;

            return query.Skip(takeRecord).Take(page.PageSize);
        }

        //public static void Update<T>(this  IQueryable<T> query, Action<T> actin)
        //{
        //    foreach (var item in query)
        //    {
        //        var tag = item;
        //        actin(tag);
        //    }
        //}
    }
}
