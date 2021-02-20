using Microsoft.AspNet.Identity.EntityFramework;
using SocialMedia.Data.Identity;
using SocialMedia.Entity.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext():base("DefaultConnection")
        {

        }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityKind> ActivityKinds { get; set; }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AskSometing> AskSometings { get; set; }
        public DbSet<CancelRequest> CancelRequests { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CuriousAbout> CuriousAbouts { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Foby> Fobies { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupKind> GroupKinds { get; set; }
        public DbSet<Hoby> Hobbies { get; set; }
        public DbSet<ImportantEvent> ImportantEvents { get; set; }
        public DbSet<Join> Joins { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MessageForUser> MessageForUsers { get; set; }
        public DbSet<OldTrip> OldTrips { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Pleasing> Pleasings { get; set; }
        public DbSet<PostShared> PostShareds { get; set; }
        public DbSet<ProfileSetting> ProfileSettings { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<SendMail> SendMails { get; set; }
        public DbSet<ToMake> ToMakes { get; set; }
        public DbSet<TripPlan> TripPlans { get; set; }
        public DbSet<UserLog> UserLogs { get; set; }
        public DbSet<VideoAd> VideoAds { get; set; }
        public DbSet<Work> Works { get; set; }
    }
}
