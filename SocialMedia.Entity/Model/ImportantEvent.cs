using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Entity.Model
{
    public class ImportantEvent : BaseHome
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public DateTime EventDate { get; set; }

        public int? MemberId { get; set; }
        public virtual Member Member { get; set; }
        public ImportantEvent()
        {
            IsConfirmed = true;
        }
    }
}
