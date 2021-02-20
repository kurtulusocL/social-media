using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Entity.Model
{
    public class FriendRequest : BaseHome
    {
        public bool IsAccepted { get; set; }

        public int? MemberId { get; set; }
        public virtual Member Member { get; set; }

        public virtual ICollection<Friend> Friends { get; set; }
        public virtual ICollection<Member> Members { get; set; }

        public FriendRequest()
        {
            IsAccepted = false;
            IsConfirmed = true;
        }
    }
}
