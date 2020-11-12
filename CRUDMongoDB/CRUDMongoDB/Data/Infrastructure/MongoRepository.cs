using CRUDMongoDB.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDMongoDB.Data.Infrastructure
{
    public abstract class MongoRepository<T> where T : class
    {
        private Entity entities;
        public MongoRepository()
        {
            entities = entities ?? (entities = new Entity());
        }
        public async Task<T> GetOneById(string id)
        {
            //var objectId = ObjectId.Empty;
            //ObjectId.TryParse(id, out objectId);

            var filter = Builders<T>.Filter.Eq("_id", id);

            var model = await entities.GetCollection<T>();

            var data = await model.FindAsync(filter);

            return data.FirstOrDefault();
        }
        public virtual IEnumerable<T> Table
        {
            get
            {
                var model = entities.GetCollection<T>().Result;

                return model.Find(Builders<T>.Filter.Empty).ToEnumerable();
            }
        }
        public async Task<IEnumerable<T>> GetMany(BsonDocument query)
        {
            var model = await entities.GetCollection<T>();

            var list = await model.FindAsync(query);

            return list.ToEnumerable();
        }
        public async Task<List<T>> GetManyToList(BsonDocument query)
        {
            var model = await entities.GetCollection<T>();

            var list = await model.FindAsync(query);

            return await list.ToListAsync();
        }
        public async Task<List<T>> GetMany(BsonDocument query, string sortColumn, bool desc = true)
        {
            var model = await entities.GetCollection<T>();

            var filter = desc ? Builders<T>.Sort.Descending(sortColumn) : Builders<T>.Sort.Ascending(sortColumn);

            var list = model.Find(query).Sort(filter);

            return await list.ToListAsync();
        }
        public async Task<MessageReport> Add(T model)
        {
            var result = new MessageReport(false, "error");

            try
            {
                var eti = await entities.GetCollection<T>();
                await eti.InsertOneAsync(model);

                result = new MessageReport(true, "Thêm mới thành công");
            }
            catch (System.Exception ex)
            {
                result = new MessageReport(false, string.Format("Message: {0} - Details: {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
            }

            return result;
        }
        public async Task<MessageReport> Update(BsonDocument query, T model)
        {
            var result = new MessageReport(false, "error");

            try
            {
                var eti = await entities.GetCollection<T>();
                await eti.FindOneAndReplaceAsync(query, model);

                result = new MessageReport(true, "Cập nhật thành công");
            }
            catch (System.Exception ex)
            {
                result = new MessageReport(false, string.Format("Message: {0} - Details: {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
            }

            return result;
        }
        public async Task<MessageReport> Remove(BsonDocument query)
        {
            var result = new MessageReport(false, "error");

            try
            {
                var eti = await entities.GetCollection<T>();
                await eti.FindOneAndDeleteAsync(query);

                result = new MessageReport(true, "Xóa thành công");
            }
            catch (System.Exception ex)
            {
                result = new MessageReport(false, string.Format("Message: {0} - Details: {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
            }

            return result;
        }
        public async Task<MessageReport> Remove_Multi(BsonDocument query)
        {
            var result = new MessageReport(false, "error");

            try
            {

                var eti = await entities.GetCollection<T>();
                await eti.DeleteManyAsync(query);

                result = new MessageReport(true, "Xóa thành công");
            }
            catch (System.Exception ex)
            {
                result = new MessageReport(false, string.Format("Message: {0} - Details: {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
            }

            return result;
        }
        public async Task<IMongoCollection<T>> GetCollection()
        {
            return await entities.GetCollection<T>();
        }
    }
}
