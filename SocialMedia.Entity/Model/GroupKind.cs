using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Entity.Model
{
    public class GroupKind : BaseHome
    {
        public string Name { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
        public GroupKind()
        {
            IsConfirmed = true;
        }
    }
}
