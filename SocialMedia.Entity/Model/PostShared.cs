using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Entity.Model
{
    public class PostShared : BaseHome
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Desc { get; set; }
        public string Url { get; set; }
        public int? Hit { get; set; }
        public int? Like { get; set; }
        public int? Dislike { get; set; }

        public string UserId { get; set; }
        public int? MemberId { get; set; }
        public virtual Member Member { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public PostShared()
        {
            IsConfirmed = true;
            Hit = 0;
            Like = 0;
            Dislike = 0;
        }
    }
}
