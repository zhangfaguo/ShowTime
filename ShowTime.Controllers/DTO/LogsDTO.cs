using ShowTime.Objects.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowTime.Controllers.DTO
{
    public class LogsDTO
    {
        public Guid ID { get; set; }

        public DateTime Create { get; set; }

        public string Message { get; set; }

        public string Express { get; set; }

        public UserDTO UserInfo { get; set; }
    }
}
