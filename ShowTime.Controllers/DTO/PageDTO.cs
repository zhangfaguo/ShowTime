using ShowTime.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ShowTime.Controllers.DTO
{
    [Bind(Exclude = "PageCount,RecordCount,List")]
    public class PageDTO<T>
    {
        public PageInfo source;

        public PageDTO()
        {
            source = new PageInfo();
        }

        public int? PageSize
        {
            get
            {
                if (source.PageSize == 0)
                    return null;
                return source.PageSize;
            }
            set
            {
                source.PageSize = value ?? 20;
            }
        }

        public int PageCount
        {
            get
            {
                return source.PageCount;
            }
            set
            {
                source.PageCount = value;
            }
        }

        public int? PageIndex
        {
            get
            {
                if (source.PageIndex == 0)
                    return null;
                return source.PageIndex;
            }
            set
            {
                source.PageIndex = value ?? 1;
            }
        }

        public int RecordCount
        {
            get
            {
                return source.RecordCount;
            }
            set
            {
                source.RecordCount = value;
            }
        }

        public IList<T> List { get; set; }
    }
}
