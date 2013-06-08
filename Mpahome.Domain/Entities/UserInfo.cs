using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Mpahome.Domain.Entities
{
    [Table("webpages_UserInfo")]
    public class UserInfo
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "用户ID")]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "真实姓名")]
        [MaxLength(128)]
        public string TrueName { get; set; }

        [Display(Name = "会员头像")]
        [MaxLength(128)]
        public string HedaImage { get; set; }

        [Required]
        [Display(Name = "班级")]
        [MaxLength(128)]
        public string Classes { get; set; }

        [Required]
        [Display(Name = "出生时间")]
        public DateTime Birthday { get; set; }

        [MaxLength(100)]
        [Display(Name = "工作单位")]
        public String Units { get; set; }

        [MaxLength(100)]
        [Display(Name = "职务")]
        public String Position { get; set; }

        [MaxLength(20)]
        [Display(Name = "联系电话")]
        public String Phone { get; set; }

        [MaxLength(20)]
        [Display(Name = "手机")]
        public String Mobile { get; set; }

        [MaxLength(500)]
        [Display(Name = "个人介绍")]
        public string Comment { get; set; }

        [ForeignKey("UserId")]
        public virtual User Users { get; set; }
    }
}
