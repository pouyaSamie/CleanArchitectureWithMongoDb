using Mongo.Repository.Abstraction;
using MongoDB.Driver;
using Repository.Abstraction;
using ServiceStack;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mongo.Repository
{
    public abstract class MongoDbRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoContext Context;
        protected IMongoCollection<TEntity> DbSet;

        protected MongoDbRepository(IMongoContext context)
        {
            Context = context;

            DbSet = Context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.InsertOneAsync(obj);
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
            return data.SingleOrDefault();
        }

        public virtual List<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {

            var data = DbSet.Find(predicate);
            return data.ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", obj.GetId()), obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id));
        }

        public void Dispose()
        {
            Context?.Dispose();
        }

        public IQueryable<TEntity> Query()
        {
            return DbSet.AsQueryable();
        }
    }
}
