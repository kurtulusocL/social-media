using SocialMedia.Business.Interfaces;
using SocialMedia.Data.Data;
using SocialMedia.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Business.Repositories
{
    public class ActivityRepository : GenericRepository<Activity>, IActivityRepository
    {
        ApplicationDbContext _db;
        public ActivityRepository()
        {
            _db = new ApplicationDbContext();
        }
        public List<Activity> GetAllIncluding()
        {
            return _db.Set<Activity>().Include("Member").Include("City").Include("ActivityKind").Include("Joins").Include("Country").ToList();
        }

        public Activity HitCount(int id)
        {
            var hit = _db.Set<Activity>().Where(i => i.Id == id).SingleOrDefault();
            hit.Hit++;
            _db.SaveChanges();
            return hit;
        }

        public void SetActive(int id)
        {
            var active = _db.Set<Activity>().Where(i => i.Id == id).FirstOrDefault();
            active.IsConfirmed = true;
            _db.SaveChanges();
        }

        public void SetDeActive(int id)
        {
            var deActive = _db.Set<Activity>().Where(i => i.Id == id).FirstOrDefault();
            deActive.IsConfirmed = false;
            _db.SaveChanges();
        }
    }
}
