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
    public class RoleDTO
    {
        public class SaveModel : BaseDTO<RoleInfo>
        {
            ///<summary>
            ///角色名称
            ///</summary>
            [Required(ErrorMessage="角色名称不能为空")]
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
        }


        public class Node
        {
            public int id { get; set; }

            public string text
            {
                get;
                set;
            }

            public IList<Node> children { get; set; }
        }
    }
}
