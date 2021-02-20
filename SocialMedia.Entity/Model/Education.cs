using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Entity.Model
{
    public class Education:BaseHome
    {
        public string Departman { get; set; }
        public string Univerity { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime? FinishingDate { get; set; }

        public int? MemberId { get; set; }
        public virtual Member Member { get; set; }
        public Education()
        {
            IsConfirmed = true;
        }
    }
}
