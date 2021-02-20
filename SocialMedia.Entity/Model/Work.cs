using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Entity.Model
{
    public class Work:BaseHome
    {
        public string Position { get; set; }
        public string CompanyName { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime? FinishingDate { get; set; }

        public int? MemberId { get; set; }
        public virtual Member Member { get; set; }
        public Work()
        {
            IsConfirmed = true;
        }
    }
}
