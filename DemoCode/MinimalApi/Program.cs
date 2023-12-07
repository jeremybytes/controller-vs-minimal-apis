using People.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IPeopleProvider, HardCodedPeopleProvider>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
    .WithName("GetPerson")
    .WithOpenApi();

app.Run();
