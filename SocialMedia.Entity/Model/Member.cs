using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Entity.Model
{
    public class Member : BaseHome
    {
        public string ShortDesc { get; set; }
        public string BioInfo { get; set; }
        public string ProfilePhoto { get; set; }
        public int? Hit { get; set; }

        public string UserId { get; set; }
        public int GenderId { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public int? ProfileSettingId { get; set; }
        public int? FriendRequestId { get; set; }
        public int? JoinId { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual ProfileSetting ProfileSetting { get; set; }
        public virtual FriendRequest FriendRequest { get; set; }
        public virtual Join Join { get; set; }

        public virtual ICollection<PostShared> PostShareds { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Report> Report { get; set; }
        public virtual ICollection<MessageForUser> MessageForUsers { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Friend> Friends { get; set; }
        public virtual ICollection<FriendRequest> FriendRequests { get; set; }
        public virtual ICollection<Work> Works { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<CuriousAbout> CuriousAbouts { get; set; }
        public virtual ICollection<Pleasing> Pleasings { get; set; }
        public virtual ICollection<TripPlan> TripPlans { get; set; }
        public virtual ICollection<OldTrip> OldTrips { get; set; }
        public virtual ICollection<AskSometing> AskSometings { get; set; }
        public virtual ICollection<Foby> Fobies { get; set; }
        public virtual ICollection<Hoby> Hobies { get; set; }
        public virtual ICollection<ImportantEvent> ImportantEvents { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public Member()
        {
            IsConfirmed = true;
            Hit = 0;
        }
    }
}
