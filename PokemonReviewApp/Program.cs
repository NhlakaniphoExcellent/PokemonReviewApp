using Microsoft.EntityFrameworkCore;
using PokemonReviewApp;
using PokemonReviewApp.DataContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container


builder.Services.AddControllers();
builder.Services.AddTransient<Seed>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PokemonReviewDB>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default Connection"));
});

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<PokemonReviewDB>(item =>
item.UseSqlServer(builder.Configuration.GetConnectionString("Default Connection")));

var app = builder.Build();

// Seeds the Data Context before the app actually starts
if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
