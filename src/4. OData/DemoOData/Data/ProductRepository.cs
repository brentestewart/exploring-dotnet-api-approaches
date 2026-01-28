using DemoOData.Models;
using System.Collections.Generic;

namespace DemoOData.Data;

public static class ProductRepository
{
    public static List<Product> Products { get; } = new List<Product>
    {
        new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200 },
        new Product { Id = 2, Name = "Phone", Category = "Electronics", Price = 800 },
        new Product { Id = 3, Name = "Desk", Category = "Furniture", Price = 300 },
        new Product { Id = 4, Name = "Chair", Category = "Furniture", Price = 150 },
    };
}