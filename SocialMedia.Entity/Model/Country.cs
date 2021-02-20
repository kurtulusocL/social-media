using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Entity.Model
{
    public class Country : BaseHome
    {
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Group> Groups { get; set; }

        public Country()
        {
            IsConfirmed = true;
        }
    }
}
