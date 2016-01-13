using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowTime.Contracts.Objects
{
    public class UserInfo
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string PassWord { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}
