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
    public class SysFunctionDTO
    {
        public class Node
        {

          
            /// <summary>
            /// 
            /// </summary>
            public int Id { get; set; }
            /// <summary>
            /// 菜单名称
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// 菜单样式
            /// </summary>
            public string Style { get; set; }
            /// <summary>
            /// 菜单父级
            /// </summary>
            public int Parent { get; set; }
            /// <summary>
            /// 菜单区域
            /// </summary>
            public string Area { get; set; }
            /// <summary>
            /// 菜单控件器
            /// </summary>
            public string Controller { get; set; }
            /// <summary>
            /// 菜单响应
            /// </summary>
            public string Action { get; set; }
            /// <summary>
            /// 是否是菜单
            /// </summary>
            public int IsMenu { get; set; }

            public string IsMenuName
            {
                get
                {
                    return IsMenu == 1 ? "是" : "否";
                }
            }


            public IList<Node> children { get; set; }
        }

        public class SaveModel : BaseDTO<SysFunctionInfo>
        {
            ///<summary>
            ///
            ///</summary>
            public int Id
            {
                get
                {
                    return Source.Id;
                }
                set
                {
                    Source.Id = value;
                }
            }
            ///<summary>
            ///菜单名称
            ///</summary>
            [Required(ErrorMessage = "菜单名称不能为空")]
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
            ///菜单样式
            ///</summary>
            public string Style
            {
                get
                {
                    return Source.Style;
                }
                set
                {
                    Source.Style = value;
                }
            }
            ///<summary>
            ///菜单父级
            ///</summary>
            public int Parent
            {
                get
                {
                    return Source.Parent;
                }
                set
                {
                    Source.Parent = value;
                }
            }
            ///<summary>
            ///菜单区域
            ///</summary>
            public string Area
            {
                get
                {
                    return Source.Area;
                }
                set
                {
                    Source.Area = value;
                }
            }
            ///<summary>
            ///菜单控件器
            ///</summary>
            public string Controller
            {
                get
                {
                    return Source.Controller;
                }
                set
                {
                    Source.Controller = value;
                }
            }
            ///<summary>
            ///菜单响应
            ///</summary>
            public string Action
            {
                get
                {
                    return Source.Action;
                }
                set
                {
                    Source.Action = value;
                }
            }
            ///<summary>
            ///是否是菜单
            ///</summary>
            public int IsMenu
            {
                get
                {
                    return Source.IsMenu;
                }
                set
                {
                    Source.IsMenu = value;
                }
            }
        }
    }
}
