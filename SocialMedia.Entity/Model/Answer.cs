using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Entity.Model
{
    public class Answer : BaseHome
    {
        public string Text { get; set; }
        public int? Hit { get; set; }
        public int? Like { get; set; }
        public int? Dislike { get; set; }

        public int? AskSomethingId { get; set; }
        public int? MemberId { get; set; }

        public virtual AskSometing AskSometing { get; set; }
        public virtual Member Member { get; set; }
        public Answer()
        {
            IsConfirmed = true;
            Hit = 0;
            Like = 0;
            Dislike = 0;
        }
    }
}
