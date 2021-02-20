using SocialMedia.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Business.Interfaces
{
    public interface ICommentRepository:IGenericRepository<Comment>
    {
        List<Comment> GetAllIncluding();
        Comment SetLike(int? id);
        Comment SetDislike(int? id);
        Comment HitCount(int id);
        void SetActive(int id);
        void SetDeActive(int id);
    }
}
