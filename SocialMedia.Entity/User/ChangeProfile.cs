using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Entity.User
{
    public class ChangeProfile
    {  
        [Required]
        [Display(Name = "Doğum Tarihiniz")]
        public DateTime Birthdate { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Adınız-Soyadınız")]
        public string NameSurname { get; set; }
       
        [Required]
        public string PhoneNumber { get; set; }       
        public DateTime UpdatedDate { get; set; }
        public bool IsConfirm { get; set; }
        public ChangeProfile()
        {
            IsConfirm = true;
        }
    }
}
