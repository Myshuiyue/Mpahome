using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Mpahome.Domain.Entities
{
    [Table("webpages_Users")]
    public class User
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Display(Name = "User Id")]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "用户名")]
        [MaxLength(100)]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z0-9.%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        [Display(Name = "邮箱")]
        [MaxLength(200)]
        public string Email { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
