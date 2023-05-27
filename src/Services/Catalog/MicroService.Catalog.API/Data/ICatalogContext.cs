using MicroService.Catalog.API.Entities;
using MongoDB.Driver;

namespace MicroService.Catalog.API.Data;

public interface ICatalogContext
{
    IMongoCollection<Product> Products { get; }
}