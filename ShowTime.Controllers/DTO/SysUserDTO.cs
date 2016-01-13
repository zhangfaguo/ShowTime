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
    public class SysUserDTO
    {

        public class UserIndexCondition : PageDTO<SysUserInfo.Search>
        {
            /// <summary>
            /// 
            /// </summary>
            public string Realname
            {
                get { return Source.RealName; }
                set { Source.RealName = value; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string Telphone
            {
                get { return Source.Tel; }
                set { Source.Tel = value; }
            }
            /// <summary>
            /// 0 待审  1审核  3驳回  4  删除
            /// </summary>
            public int? Statue
            {
                get
                {
                    if (Source.Statue == 0)
                    {
                        return null;
                    }
                    return Source.Statue;
                }
                set { Source.Statue = value ?? 0; }
            }

        }

        public class SaveModel : BaseDTO<SysUserInfo>
        {
            ///<summary>
            ///
            ///</summary>
            public int? Id
            {
                get
                {
                    return Source.Id;
                }
                set
                {
                    Source.Id = value ?? 0;
                }
            }
            ///<summary>
            ///用户名
            ///</summary>
            [Required(ErrorMessage="用户名不能为空")]
            public string Name
            {
                get
                {
                    return Source.Name;
                }
                set
                {
                    Source.Name = value;
                }
            }
            ///<summary>
            ///登录密码
            ///</summary>
            [Required(ErrorMessage = "密码不能为空")]
            public string Password
            {
                get
                {
                    return Source.Password;
                }
                set
                {
                    Source.Password = value;
                }
            }
            ///<summary>
            ///真实姓名
            ///</summary>
            [Required(ErrorMessage = "姓名不能为空")]
            public string RealName
            {
                get
                {
                    return Source.RealName;
                }
                set
                {
                    Source.RealName = value;
                }
            }
            ///<summary>
            ///电话
            ///</summary>
            public string Tel
            {
                get
                {
                    return Source.Tel;
                }
                set
                {
                    Source.Tel = value;
                }
            }
            ///<summary>
            ///
            ///</summary>
            public int RoleId
            {
                get
                {
                    return Source.RoleId;
                }
                set
                {
                    Source.RoleId = value;
                }
            }

            ///<summary>
            ///状态
            ///</summary>
            public int Statue
            {
                get
                {
                    return Source.Statue;
                }
                set
                {
                    Source.Statue = value;
                }
            }

        }
    }
}
