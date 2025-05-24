using Microsoft.EntityFrameworkCore;
using PetAdoptionMAUI.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Pet");
builder.Services.AddDbContext<PetContext>( opt => opt.UseSqlServer(connectionString), ServiceLifetime.Transient);

var app = builder.Build();

// Apply database migrations
ApplyDbMigrations(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run("https://localhost:5289");

static void ApplyDbMigrations(IServiceProvider serviceProvider)
{
    using (var scope = serviceProvider.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<PetContext>();
        if(dbContext.Database.GetPendingMigrations().Any())
            dbContext.Database.Migrate();
    }
}
