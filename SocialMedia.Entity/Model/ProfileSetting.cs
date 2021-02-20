using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Entity.Model
{
    public class ProfileSetting : BaseHome
    {
        public bool IsSecret { get; set; }
        public bool IsSentFreiendship { get; set; }
        public bool IsTakeFriendship { get; set; }
        public bool IsTakeComment { get; set; }
        public bool IsTakeLike { get; set; }
        public bool IsTakeDislike { get; set; }

        public virtual ICollection<Member> Members { get; set; }
        public ProfileSetting()
        {
            IsConfirmed = true;
        }
    }
}
