using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IAppUserService
    {
        List<AppUser> GetListAll();
        AppUser GetById(string id);
        List<AppUser> GetByFilter(string? userName);
        AppUser Insert(AppUser appuser);
        void Update(string id, AppUser appuser);
        void Delete(string id);
    }
}
