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
    public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
    {
        ApplicationDbContext _db;
        public AnswerRepository()
        {
            _db = new ApplicationDbContext();
        }
        public List<Answer> GetAllIncluding()
        {
            return _db.Set<Answer>().Include("AskSometing").Include("Member").ToList();
        }

        public Answer HitCount(int id)
        {
            var hit = _db.Set<Answer>().Where(i => i.Id == id).SingleOrDefault();
            hit.Hit++;
            _db.SaveChanges();
            return hit;
        }

        public void SetActive(int id)
        {
            var active = _db.Set<Answer>().Where(i => i.Id == id).FirstOrDefault();
            active.IsConfirmed = true;
            _db.SaveChanges();
        }

        public void SetDeActive(int id)
        {
            var deActive = _db.Set<Answer>().Where(i => i.Id == id).FirstOrDefault();
            deActive.IsConfirmed = false;
            _db.SaveChanges();
        }

        public Answer SetDislike(int? id)
        {
            var dislike = _db.Set<Answer>().Where(i => i.Id == id).SingleOrDefault();
            dislike.Like--;
            _db.SaveChanges();
            return dislike;
        }

        public Answer SetLike(int? id)
        {
            var like = _db.Set<Answer>().Where(i => i.Id == id).SingleOrDefault();
            like.Like++;
            _db.SaveChanges();
            return like;
        }
    }
}
