var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var employees = new List<Person>
{
    new Person(1, "Alice", 30),
    new Person(2, "Bob", 25),
    new Person(3, "Charlie", 35)
};

app.MapGet("/employees", () => employees);

app.MapGet("/employee/{id}", (int id) =>
{
    var employee = employees.FirstOrDefault(e => e.Id == id);
    return employee is not null ? Results.Ok(employee) : Results.NotFound();
});

app.MapPost("/employee", (Person person) =>
{
    var maxId = employees.Max(e => e.Id);
    person = person with { Id = maxId + 1 };
    employees.Add(person);
    return Results.Created($"/employee/{person.Id}", person);
});

app.Run();


record Person(int Id, string Name, int Age);
