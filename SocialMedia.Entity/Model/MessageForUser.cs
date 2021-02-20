using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Entity.Model
{
    public class MessageForUser : BaseHome
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Text { get; set; }
        public int? Hit { get; set; }

        public int? MemberId { get; set; }
        public virtual Member Member { get; set; }
        public MessageForUser()
        {
            Hit = 0;
            IsConfirmed = true;
        }
    }
}
