using CRUDMongoDB.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDMongoDB.Data.Infrastructure
{
    public interface IMongoDBRepository<T> where T : class
    {
        Task<T> GetOneById(string id);

        IEnumerable<T> Table { get; }

        Task<IEnumerable<T>> GetMany(BsonDocument query);

        Task<List<T>> GetManyToList(BsonDocument query);

        Task<List<T>> GetMany(BsonDocument query, string sortColumn, bool desc = true);

        //Task<GridModel<T>> GetPaging(BsonDocument query, BsonDocument sortColumns, int pageIndex, int pageSize);

        Task<MessageReport> Add(T model);

        Task<MessageReport> Update(BsonDocument query, T model);

        Task<MessageReport> Remove(BsonDocument query);

        Task<MessageReport> Remove_Multi(BsonDocument query);

        Task<IMongoCollection<T>> GetCollection();
    }
}
