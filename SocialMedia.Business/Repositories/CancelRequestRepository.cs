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
    public class CancelRequestRepository : GenericRepository<CancelRequest>, ICancelRequestRepository
    {
        ApplicationDbContext _db;
        public CancelRequestRepository()
        {
            _db = new ApplicationDbContext();
        }
        public void SetActive(int id)
        {
            var active = _db.Set<CancelRequest>().Where(i => i.Id == id).FirstOrDefault();
            active.IsConfirmed = true;
            _db.SaveChanges();
        }

        public void SetDeActive(int id)
        {
            var deActive = _db.Set<CancelRequest>().Where(i => i.Id == id).FirstOrDefault();
            deActive.IsConfirmed = false;
            _db.SaveChanges();
        }
    }
}
