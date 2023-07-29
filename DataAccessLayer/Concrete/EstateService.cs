using DataAccessLayer.Abstract;
using EntityLayer;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class EstateService : IEstateService
    {
        private readonly IMongoCollection<Estate> _estate;

        public EstateService(Abstract.IEstateStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _estate = database.GetCollection<Estate>(settings.EstateCollectionName);
        }

        public void Delete(string id)
        {
            _estate.DeleteOne(estate => estate.Id == id);
        }

        public List<Estate> GetByFilter(string? city, string? des, int? room, string? title, int? price, string? buildYear, string? imageurl)
        {
            var filterBuilder = Builders<Estate>.Filter;
            var filter = filterBuilder.Empty;

            if (!string.IsNullOrEmpty(city))
            {
                filter = filter & filterBuilder.Where(estate => estate.City.ToLower().Contains(city.ToLower()));
            }

            if (!string.IsNullOrEmpty(des))
            {
                filter = filter & filterBuilder.Where(estate => estate.Des.ToLower().Contains(des.ToLower()));
            }

            if (room.HasValue)
            {
                filter = filter & filterBuilder.Eq(estate => estate.Room, room.Value);
            }

            if (!string.IsNullOrEmpty(title))
            {
                filter = filter & filterBuilder.Where(estate => estate.Title.ToLower().Contains(title.ToLower()));
            }

            if (price.HasValue)
            {
                filter = filter & filterBuilder.Eq(estate => estate.Price, price.Value);
            }

            if (!string.IsNullOrEmpty(buildYear))
            {
                filter = filter & filterBuilder.Eq(estate => estate.BuildYear, buildYear);
            }

            if (!string.IsNullOrEmpty(imageurl))
            {
                filter = filter & filterBuilder.Eq(estate => estate.ImageURL, buildYear);
            }

            return _estate.Find(filter).ToList();
        }

        public Estate GetById(string id)
        {
            return _estate.Find(estate => estate.Id == id).FirstOrDefault();
        }

        public List<Estate> GetListAll()
        {
            return _estate.Find(estate => true).ToList();
        }

        public Estate Insert(Estate estate)
        {
            estate.Id = ObjectId.GenerateNewId().ToString();
            _estate.InsertOne(estate);
            return estate;
        }
        public void Update(string id, Estate estate)
        {
            _estate.ReplaceOne(estate => estate.Id == id, estate);
        }
    }
}
