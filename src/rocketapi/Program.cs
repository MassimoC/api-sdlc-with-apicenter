using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var names = new[]
{
   "Saturn V","Space Shuttle","Falcon 9","Atlas V","Delta IV","Soyuz","Proton","Ariane 5","H-IIA","Long March series","Vega","Antares","New Shepard","Electron","Titan II","Pegasus"
};

app.MapGet("/rockets", () =>
{
    var wellKnownRockets = Enumerable.Range(1, 5).Select(index =>
        new RocketFile
        (
            names[Random.Shared.Next(names.Length)],
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(1, 100)
        ))
        .ToArray();
    return wellKnownRockets;
})
.WithName("GetRocketNames")
.WithOpenApi();

app.Run();

internal record RocketFile(string Name, DateOnly Date, int ChanceOfFailure)
{
    public string KeyCode => Convert.ToBase64String(Encoding.UTF8.GetBytes(Name));

}
