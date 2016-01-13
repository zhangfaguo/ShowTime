using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowTime.Objects.Objects
{
    public class LogsInfo
    {
        public Guid ID { get; set; }

        public DateTime Create { get; set; }

        public string Message { get; set; }

        public string Express { get; set; }

        public int UserId { get; set; }

        public  UserInfo UserInfo { get; set; }


        public class SearchPage : PageInfo
        {

            public string Message { get; set; }
        }

    }
}
