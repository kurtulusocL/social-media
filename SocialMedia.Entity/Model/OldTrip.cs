using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Entity.Model
{
    public class OldTrip : BaseHome
    {
        public string Name { get; set; }
        public string FromWhere { get; set; }
        public string ToWhere { get; set; }
        public DateTime TripDate { get; set; }

        public int? MemberId { get; set; }
        public virtual Member Member { get; set; }
        public OldTrip()
        {
            IsConfirmed = true;
        }
    }
}
