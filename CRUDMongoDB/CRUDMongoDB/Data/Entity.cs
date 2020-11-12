using CRUDMongoDB.Library.Helper;
using CRUDMongoDB.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDMongoDB.Data
{
    public class Entity : DbContext
    {
        private IMongoClient _MongoClient;
        private IMongoDatabase _MongoDatabase;
        public Entity(DbContextOptions<Entity> options) : base(options)
        {

        }
        public Entity()
        {
            var mongoUrl = new MongoUrl(AppSettingHelper.GetStringFromFileJson("connectstring", "ConnectionStrings:DefaultConnection").Result);

            _MongoClient = new MongoClient(mongoUrl.ToString().Replace(@"/" + mongoUrl.DatabaseName, ""));

            _MongoDatabase = _MongoClient.GetDatabase(mongoUrl.DatabaseName);
        }
        public DbSet<Student> student {get; set; }
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>(entity =>
           {
               entity.HasKey(e => e.Id);
               entity.Property(e => e.FullName).IsRequired();
               entity.Property(e => e.Address).IsRequired();
               entity.Property(e => e.Age).IsRequired();
               entity.Property(e => e.DateCreate).IsRequired();
               entity.Property(e => e.IsDelete).IsRequired();
           });
        }
        public async Task<IMongoCollection<T>> GetCollection<T>()
        {
            var exist = await CollectionExistsAsync(typeof(T).Name);
            if (exist == false)
            {
                _MongoDatabase.CreateCollection(typeof(T).Name);
            }
            return await Task.FromResult(_MongoDatabase.GetCollection<T>(typeof(T).Name));
        }

        private async Task<bool> CollectionExistsAsync(string collectionName    )
        {
            var filter = new BsonDocument("name", collectionName);

            //filter by collection name
            var collections = await _MongoDatabase.ListCollectionsAsync(new ListCollectionsOptions { Filter = filter });

            //check for existence
            return await collections.AnyAsync();
        }
    }
}
