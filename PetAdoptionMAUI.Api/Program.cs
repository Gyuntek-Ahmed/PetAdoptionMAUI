using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using PetAdoptionMAUI.Api.Data;
using PetAdoptionMAUI.Api.Services;
using PetAdoptionMAUI.Api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(jwtOptions
               => jwtOptions
                 .TokenValidationParameters = TokenService.GetTokenValidationParameters(builder.Configuration));

var connectionString = builder.Configuration.GetConnectionString("Pet");
builder.Services.AddDbContext<PetContext>( opt => opt.UseSqlServer(connectionString), ServiceLifetime.Transient);

// Register services
builder.Services
    .AddTransient<IAuthService, AuthService>()
    .AddTransient<TokenService>()
    .AddTransient<IUserPetService, UserPetService>()
    .AddTransient<IPetService, PetService>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run("https://localhost:7056");

static void ApplyDbMigrations(IServiceProvider serviceProvider)
{
    using (var scope = serviceProvider.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<PetContext>();
        if(dbContext.Database.GetPendingMigrations().Any())
            dbContext.Database.Migrate();
    }
}
