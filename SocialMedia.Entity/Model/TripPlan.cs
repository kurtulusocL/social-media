using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Entity.Model
{
    public class TripPlan : BaseHome
    {
        public string Name { get; set; }
        public string FromWhere { get; set; }
        public string ToWhere { get; set; }
        public DateTime PlanDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public int? MemberId { get; set; }
        public virtual Member Member { get; set; }
        public TripPlan()
        {
            IsConfirmed = true;
        }
    }
}
