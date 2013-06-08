using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Mpahome.Domain.Entities
{
    [Table("webpages_OAuthMembership")]
    public class OAuthMembership
    {
        
        [Required]
        [Display(Name = "Provider")]
        [MaxLength(30)]
        public string Provider{get;set;}

        
        [Required]
        [Display(Name = "ProviderUserId")]
        [MaxLength(30)]
        public string ProviderUserId{get;set;}

        [Required]
        [Display(Name = "UserId")]
        public int UserId { get; set; }


    }
}
