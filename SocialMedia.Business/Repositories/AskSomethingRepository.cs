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
    public class AskSomethingRepository : GenericRepository<AskSometing>, IAskSomethingRepository
    {
        ApplicationDbContext _db;
        public AskSomethingRepository()
        {
            _db = new ApplicationDbContext();
        }
        public List<AskSometing> GetAllIncluding()
        {
            return _db.Set<AskSometing>().Include("Answers").Include("Member").ToList();
        }

        public AskSometing HitCount(int id)
        {
            var hit = _db.Set<AskSometing>().Where(i => i.Id == id).SingleOrDefault();
            hit.Hit++;
            _db.SaveChanges();
            return hit;
        }

        public void SetActive(int id)
        {
            var active = _db.Set<AskSometing>().Where(i => i.Id == id).FirstOrDefault();
            active.IsConfirmed = true;
            _db.SaveChanges();
        }

        public void SetDeActive(int id)
        {
            var deActive = _db.Set<AskSometing>().Where(i => i.Id == id).FirstOrDefault();
            deActive.IsConfirmed = false;
            _db.SaveChanges();
        }

        public AskSometing SetDislike(int? id)
        {
            var dislike = _db.Set<AskSometing>().Where(i => i.Id == id).SingleOrDefault();
            dislike.Like--;
            _db.SaveChanges();
            return dislike;
        }

        public AskSometing SetLike(int? id)
        {
            var like = _db.Set<AskSometing>().Where(i => i.Id == id).SingleOrDefault();
            like.Like++;
            _db.SaveChanges();
            return like;
        }
    }
}
