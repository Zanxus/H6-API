using H6_API.Application.Services;
using H6_API.ApplicationConfig;
using H6_API.Domain.DTO;
using H6_API.Domain.Entites;
using H6_API.Domain.Interfaces.Repositories;
using H6_API.Domain.Interfaces.Services;
using H6_API.Infrastructure.Data;
using H6_API.Infrastructure.Repositoies;
using H6_API.Presentation.ApplicationConfig;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<WatchMateDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("H6_API.Infrastructure")));
builder.Services.AddControllers();

builder.Services.Configure<OMDBSettings>(builder.Configuration.GetSection("OMDBSettings"));

builder.Services.AddHttpClient<IOMDBService, OMDBService>(client =>
    client.BaseAddress = new Uri(builder.Configuration["OMDBBaseURL"]
    ));

builder.Services.AddScoped<IOMDBService, OMDBService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddLocalApiAuthentication();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<WatchMateDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityServer()
    .AddInMemoryIdentityResources(IdentityServerConfig.IdentityResources)
    .AddInMemoryApiScopes(IdentityServerConfig.ApiScopes)
    .AddInMemoryClients(IdentityServerConfig.Clients)
    .AddAspNetIdentity<ApplicationUser>()
    .AddDeveloperSigningCredential();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:5001";

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };

        options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };

    });

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("Dev",
            policy =>
            {
                policy
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
    });
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("Dev");
}

//app.UseHttpsRedirection();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
