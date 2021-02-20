using SocialMedia.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Business.Interfaces
{
    public interface IActivityRepository:IGenericRepository<Activity>
    {
        List<Activity> GetAllIncluding();
        Activity HitCount(int id);
        void SetActive(int id);
        void SetDeActive(int id);
    }
}
