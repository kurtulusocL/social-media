using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Entity.Model
{
    public class Contact : BaseHome
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public int? MemberId { get; set; }
        public virtual Member Member { get; set; }
        public Contact()
        {
            IsConfirmed = true;
        }
    }
}
