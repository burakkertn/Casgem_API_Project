using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IEstateService
    {
        List<Estate> GetListAll();
        Estate GetById(string id);
        List<Estate> GetByFilter(string? city, string? des, int? room, string? title, int? price, string? buildYear, string? imageurl);
        Estate Insert(Estate estate);
        void Update(string id, Estate estate);
        void Delete(string id);
    }
}
