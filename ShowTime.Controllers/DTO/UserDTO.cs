using System;
using System.Web.Mvc;
using System.Collections.Generic;
using ShowTime.Objects.Objects;
using ShowTime.Controllers.DTO.Base;

namespace ShowTime.Controllers.DTO
{
    public class UserDTO 
    {
         public class SaveModel : BaseDTO<UserInfo>
         {
            
            ///<summary>
            ///
            ///</summary>
            public int Id
            {
                get{ 
                   return Source.Id;
                }
                set{
                     Source.Id=value;
                }
            }

            
            ///<summary>
            ///手机号
            ///</summary>
            public string TelPhone
            {
                get{ 
                   return Source.TelPhone;
                }
                set{
                     Source.TelPhone=value;
                }
            }

            
            ///<summary>
            ///登录密码
            ///</summary>
            public string PassWord
            {
                get{ 
                   return Source.PassWord;
                }
                set{
                     Source.PassWord=value;
                }
            }

            
            ///<summary>
            ///真实姓名
            ///</summary>
            public string RealName
            {
                get{ 
                   return Source.RealName;
                }
                set{
                     Source.RealName=value;
                }
            }

            
            ///<summary>
            ///身份证号
            ///</summary>
            public string IdCard
            {
                get{ 
                   return Source.IdCard;
                }
                set{
                     Source.IdCard=value;
                }
            }

            
            ///<summary>
            ///居住地址
            ///</summary>
            public string Adress
            {
                get{ 
                   return Source.Adress;
                }
                set{
                     Source.Adress=value;
                }
            }

            
            ///<summary>
            ///备注
            ///</summary>
            public string ReMark
            {
                get{ 
                   return Source.ReMark;
                }
                set{
                     Source.ReMark=value;
                }
            }

            
            ///<summary>
            ///邮箱
            ///</summary>
            public string EMail
            {
                get{ 
                   return Source.EMail;
                }
                set{
                     Source.EMail=value;
                }
            }

            
        }
    }
}