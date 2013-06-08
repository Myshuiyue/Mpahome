using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Mpahome.Domain.Entities
{
    [Table("webpages_Toles")]
    public class Role
    {
        [Key]
        [Display(Name = "ID")]
        public int RoleId { get; set; }

        [Display(Name = "名称")]
        [StringLength(256)]
        public string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
