using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using DemoOData.Models;

var builder = WebApplication.CreateBuilder(args);

// Add OData controllers
builder.Services.AddControllers()
    .AddOData(opt =>
    {
        var odataBuilder = new ODataConventionModelBuilder();
        odataBuilder.EntitySet<Product>("Products");
        opt.AddRouteComponents("odata", odataBuilder.GetEdmModel())
           .Select()
           .Filter()
           .OrderBy()
           .Count()
           .Expand()
           .SetMaxTop(100);
    });

// OpenAPI / Swagger
builder.Services.AddOpenApi();

var app = builder.Build();

// OpenAPI in development
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// **Map controllers (OData needs this!)**
app.MapControllers();

app.Run();