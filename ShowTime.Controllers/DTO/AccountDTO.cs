using ShowTime.Core.ViewModel;
using ShowTime.DomainService.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowTime.Controllers.DTO
{
    public class AccountDTO
    {
        public class LoginModel : BaseDTO<SysUserInfo.LoginModel>
        {
            [Required(ErrorMessage = "登录名不能为空")]
            public string LoginName { get { return Source.Name; } set { Source.Name = value; } }
            [Required(ErrorMessage = "密码不能为空")]
            public string LoginPwd { get { return Source.Password; } set { Source.Password = value; } }

            public bool IsRemenberMe { get; set; }
        }
    }
}
