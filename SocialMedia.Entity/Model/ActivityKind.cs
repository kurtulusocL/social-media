using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Entity.Model
{
    public class ActivityKind : BaseHome
    {
        public string Name { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
        public ActivityKind()
        {
            IsConfirmed = true;
        }
    }
}
