using BusinessLayer.Abstarct;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserService _appUserService;

        public AppUserManager(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public void TDelete(AppUser t)
        {

            _appUserService.TDelete(t);
        }

        public AppUser TGetByID(string id)
        {
            return _appUserService.TGetByID(id);

        }

        public List<AppUser> TGetList()
        {
            return _appUserService.TGetList();

        }

        public void TInsert(AppUser t)
        {

            _appUserService.TInsert(t);
        }

        public void TUpdate(AppUser t)
        {
            _appUserService.TUpdate(t);

        }
    }
}
