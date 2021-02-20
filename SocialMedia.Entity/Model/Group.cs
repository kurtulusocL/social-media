using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Entity.Model
{
    public class Group : BaseHome
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public bool IsPrivate { get; set; }
        public string Photo { get; set; }
        public int? Hit { get; set; }

        public int GroupKindId { get; set; }
        public int? MemberId { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }

        public virtual Member Member { get; set; }
        public virtual GroupKind GroupKind { get; set; }
        public virtual City City { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<Join> Joins { get; set; }
        public Group()
        {
            IsConfirmed = true;
            Hit = 0;
        }
    }
}
