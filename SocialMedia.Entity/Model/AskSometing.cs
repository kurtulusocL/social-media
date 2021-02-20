using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Entity.Model
{
    public class AskSometing : BaseHome
    {
        public string Question { get; set; }
        public int? Hit { get; set; }
        public int? Like { get; set; }
        public int? Dislike { get; set; }

        public int? MemberId { get; set; }
        public virtual Member Member { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        public AskSometing()
        {
            IsConfirmed = true;
            Hit = 0;
            Like = 0;
            Dislike = 0;
        }
    }
}
