using Domain.Entities;
using Mongo.Repository;
using Mongo.Repository.Abstraction;


namespace Infrastructure.Persistence
{
    internal class TodoItemRepository : MongoDbRepository<TodoItem>
    {
        public TodoItemRepository(IMongoContext context) : base(context)
        {
        }
    }

   
}
