using SocialMedia.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Business.Interfaces
{
    public interface IAskSomethingRepository:IGenericRepository<AskSometing>
    {
        List<AskSometing> GetAllIncluding();
        AskSometing SetLike(int? id);
        AskSometing SetDislike(int? id);
        AskSometing HitCount(int id);
        void SetActive(int id);
        void SetDeActive(int id);
    }
}
