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
    public class AppUserService : IAppUserService
    {
        private readonly IMongoCollection<AppUser> _users;

        public AppUserService(Abstract.IEstateStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<AppUser>(settings.AppUserCollectionName);
        }

        public void Delete(string id)
        {
            _users.DeleteOne(user => user.Id == id);
        }

        public List<AppUser> GetByFilter(string? userName)
        {
            var filterBuilder = Builders<AppUser>.Filter;
            var filter = filterBuilder.Empty;

            if (!string.IsNullOrEmpty(userName))
            {
                filter = filter & filterBuilder.Where(user => user.UserName.ToLower().Contains(userName.ToLower()));
            }

            return _users.Find(filter).ToList();
        }

        public AppUser GetById(string id)
        {
            return _users.Find(user => user.Id == id).FirstOrDefault();
        }

        public List<AppUser> GetListAll()
        {
            return _users.Find(user => true).ToList();
        }

        public AppUser Insert(AppUser user)
        {
            user.Id = ObjectId.GenerateNewId().ToString();
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, AppUser user)
        {
            _users.ReplaceOne(user => user.Id == id, user);
        }
    }
}
