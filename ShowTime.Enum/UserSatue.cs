using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowTime.Enum
{
    public enum UserStatue
    {
        [Description("正常")]
        Success = 1,

        [Description("锁定")]
        Lock
    }
}
