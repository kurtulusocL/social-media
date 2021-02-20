using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Entity.Model
{
    public class Comment : BaseHome
    {
        public string Text { get; set; }
        public string Photo { get; set; }
        public int? Hit { get; set; }
        public int? Like { get; set; }
        public int? Dislike { get; set; }

        public int? PostSharedId { get; set; }
        public int? MemberId { get; set; }
        public virtual PostShared PostShared { get; set; }
        public virtual Member Member { get; set; }

        public virtual ICollection<Report> Reports { get; set; }

        public Comment()
        {
            IsConfirmed = true;
            Hit = 0;
            Like = 0;
            Dislike = 0;
        }
    }
}
