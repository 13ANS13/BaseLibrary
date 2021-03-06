﻿using BaseLibrary.Mongo.DbContext.Interfaces;
using BaseLibrary.Mongo.Repository;
using Sample.Mongo.Entities;
using Sample.Mongo.Repositories.Interfaces;

namespace Sample.Mongo.Repositories
{
    public class ProductRepository : MongoRepository<Product>, IProductRepository
    {
        public ProductRepository(IMongoContext mongoContext) : base(mongoContext)
        {

        }
    }
}
