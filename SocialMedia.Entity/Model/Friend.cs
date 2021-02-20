using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Entity.Model
{
    public class Friend : BaseHome
    {
        public int? MemberId { get; set; }
        public int? FriendRequestId { get; set; }

        public virtual Member Member { get; set; }
        public virtual FriendRequest FriendRequest { get; set; }

        public Friend()
        {
            IsConfirmed = true;
        }
    }
}
