using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using DemoOData.Data;
using DemoOData.Models;

namespace DemoOData.Controllers;

public class ProductsController : ODataController
{
    [EnableQuery]
    public IQueryable<Product> Get()
    {
        return ProductRepository.Products.AsQueryable();
    }
}