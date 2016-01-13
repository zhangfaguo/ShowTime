using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowTime.Objects.Model
{
    /// <summary>
    /// ShowTime
    /// </summary>
    [Table("User")]
    public class User
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [StringLength(12)]
        [Index(IsUnique = true)]
        public string TelPhone { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        [StringLength(23)]
        public string PassWord { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        [StringLength(30)]
        public string RealName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        [StringLength(20)]
        public string IdCard { get; set; }
        /// <summary>
        /// 居住地址
        /// </summary>
        [StringLength(100)]
        public string Adress { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string ReMark { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [StringLength(100)]
        public string EMail { get; set; }

    }
}