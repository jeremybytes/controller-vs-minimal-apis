using MinimalApi;
using People.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IPeopleProvider, HardCodedPeopleProvider>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Set JSON indentation
builder.Services.ConfigureHttpJsonOptions(options => options.SerializerOptions.WriteIndented = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/people",
    async (IPeopleProvider provider) => await provider.GetPeople())
    .WithName("GetPeople")
    .WithOpenApi();

app.MapGet("/people/{id}",
    async (int id, IPeopleProvider provider) => await provider.GetPerson(id))
    .WithName("GetPersonV1")
    .WithOpenApi();

app.MapGet("/people/v2/{id}", 
    async (int id, IPeopleProvider provider) =>
    {
        var person = await provider.GetPerson(id);
        return person switch
        {
            null => Results.NoContent(),
            _ => Results.Json(person)
        };
    })
    .WithName("GetPersonV2")
    .WithOpenApi();

app.MapGet("/people/v3/{id}",
    async (int id, IPeopleProvider provider) => await ApiMethods.TestableCall(id, provider))
    .WithName("GetPersonV3")
    .WithOpenApi();

app.Run();
