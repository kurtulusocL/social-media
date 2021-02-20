using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Entity.Model
{
    public class Report : BaseHome
    {
        public string Subject { get; set; }
        public string Problem { get; set; }

        public int? MemberId { get; set; }
        public int? PostSharedId { get; set; }
        public int? CommentId { get; set; }

        public virtual Member Member { get; set; }
        public virtual PostShared PostShared { get; set; }
        public virtual Comment Comment { get; set; }
        public Report()
        {
            IsConfirmed = true;
        }
    }
}
