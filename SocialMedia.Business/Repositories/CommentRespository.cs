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
    public class CommentRespository : GenericRepository<Comment>, ICommentRepository
    {
        ApplicationDbContext _db;
        public CommentRespository()
        {
            _db = new ApplicationDbContext();
        }
        public List<Comment> GetAllIncluding()
        {
            return _db.Set<Comment>().Include("PostShared").Include("Reports").Include("Member").ToList();
        }

        public Comment HitCount(int id)
        {
            var hit = _db.Set<Comment>().Where(i => i.Id == id).SingleOrDefault();
            hit.Hit++;
            _db.SaveChanges();
            return hit;
        }

        public void SetActive(int id)
        {
            var active = _db.Set<Comment>().Where(i => i.Id == id).FirstOrDefault();
            active.IsConfirmed = true;
            _db.SaveChanges();
        }

        public void SetDeActive(int id)
        {
            var deActive = _db.Set<Comment>().Where(i => i.Id == id).FirstOrDefault();
            deActive.IsConfirmed = false;
            _db.SaveChanges();
        }

        public Comment SetDislike(int? id)
        {
            var like = _db.Set<Comment>().Where(i => i.Id == id).SingleOrDefault();
            like.Like--;
            _db.SaveChanges();
            return like;
        }

        public Comment SetLike(int? id)
        {
            var like = _db.Set<Comment>().Where(i => i.Id == id).SingleOrDefault();
            like.Like++;
            _db.SaveChanges();
            return like;
        }
    }
}
