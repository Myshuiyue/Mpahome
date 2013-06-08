using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpahome.Domain.Entities
{
    [Table("webpages_Blogs")]
    public class Blog
    {
        public int Id { get; set; }
        public int Category { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AddDate { get; set; }

        [ForeignKey("UserId")]
        public virtual User Users { get; set; }
    }
}
