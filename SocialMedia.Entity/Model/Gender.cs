using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Entity.Model
{
    public class Gender : BaseHome
    {
        public string Name { get; set; }

        public virtual ICollection<Member> Members { get; set; }
        public Gender()
        {
            IsConfirmed = true;
        }
    }
}
