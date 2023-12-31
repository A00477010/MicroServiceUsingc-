using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Play.catalog.service.Entities;

namespace Play.catalog.service.Repositories
{
    public class ItemRepository
    {
        private const String collectionName="items";
        private readonly IMongoCollection<Item> dbCollection;
        private readonly FilterDefinitionBuilder<Item> filterBuilder=Builders<Item>.Filter;
        public ItemRepository()
        {
            var mongoClient=new MongoClient("mongodb://localhost:27017");
            var database=mongoClient.GetDatabase("Catalog");
            dbCollection=database.GetCollection<Item>(collectionName);

        }

        public async Task<IReadOnlyCollection<Item>> GetAllAsync()
        {
            return await dbCollection.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task<Item> GetAsync(Guid id){
            FilterDefinition<Item> filter=filterBuilder.Eq(entity=>entity.Id,id);
            return await dbCollection.Find(filter).FirstOrDefaultAsync();
        }
        public async Task CreateAsync(Item entity){
            if(entity==null){
                throw new ArgumentException(nameof(entity));
            }
            await dbCollection.InsertOneAsync(entity);
        }

        public async Task updateAsync(Item entity){
            if(entity==null){
                throw new ArgumentException(nameof(entity));
            }
            FilterDefinition<Item> filter= filterBuilder.Eq(existingEntity=>existingEntity.Id,entity.Id);
            await dbCollection.ReplaceOneAsync(filter,entity);

        }
        public async Task RemoveAsync(Guid id){
            FilterDefinition<Item> filter= filterBuilder.Eq(entity=>entity.Id,id);
            await dbCollection.DeleteOneAsync(filter);
        }


    }
}
