using BusinessLayer.Abstarct;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class EstateManager : IEstateService
    {
        private readonly IEstateService _estateService;

        public EstateManager(IEstateService estateService)
        {
            _estateService = estateService;
        }

        public void TDelete(Estate t)
        {
            _estateService.TDelete(t);
        }

        public Estate TGetByID(string id)
        {
           return _estateService.TGetByID(id);
        }

        public List<Estate> TGetList()
        {
           return _estateService.TGetList();
        }

        public void TInsert(Estate t)
        {
            _estateService.TInsert(t);
        }

        public void TUpdate(Estate t)
        {
            _estateService.TUpdate(t);
        }
    }
}
