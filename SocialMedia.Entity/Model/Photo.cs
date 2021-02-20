using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Entity.Model
{
    public class Photo : BaseHome
    {
        public string ImageUrl { get; set; }

        public string UserId { get; set; }
        public int? PostSharedId { get; set; }
        public virtual PostShared PostShared { get; set; }
        public Photo()
        {
            IsConfirmed = true;
        }
    }
}
