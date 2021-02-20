using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Entity.Model
{
    public class Join : BaseHome
    {
        public bool IsBlocked { get; set; }
        public bool IsJoined { get; set; }

        public int? ActivityId { get; set; }
        public int? GroupId { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual Group Group { get; set; }

        public virtual ICollection<Member> Members { get; set; }
        public Join()
        {
            IsBlocked = false;
            IsConfirmed = true;
            IsJoined = false;
        }
    }
}
