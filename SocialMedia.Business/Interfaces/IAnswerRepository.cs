using SocialMedia.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Business.Interfaces
{
    public interface IAnswerRepository:IGenericRepository<Answer>
    {
        List<Answer> GetAllIncluding();
        Answer SetLike(int? id);
        Answer SetDislike(int? id);
        Answer HitCount(int id);
        void SetActive(int id);
        void SetDeActive(int id);
    }
}
