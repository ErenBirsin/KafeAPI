using KafeAPI.Application.Interfaces;
using KafeAPI.Application.Mapping;
using KafeAPI.Application.Services.Abstract;
using KafeAPI.Application.Services.Concrete;
using KafeAPI.Persistence.Context;
using KafeAPI.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scalar.AspNetCore;
using AutoMapper;
using FluentValidation;
using KafeAPI.Application.Dtos.CategoryDtos;
using KafeAPI.Application.Dtos.MenuItemsDtos;
using KafeAPI.Application.Dtos.TableDtos;
using KafeAPI.Application.Dtos.OrderDtos;
using KafeAPI.Application.Dtos.OrderItemDtos;
using KafeAPI.Application.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using KafeAPI.Persistence.Context.Identity;
using Microsoft.AspNetCore.Identity;
using Serilog;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using CafeAPI.Persistence.Middleware;
using AspNetCoreRateLimit;
using KafeAPI.Application.Dtos.CafeInfoDtos;
using KafeAPI.Application.Dtos.ReviewDtos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    var configuration = builder.Configuration;
    var database = configuration.GetConnectionString("DefaultConnection");
    opt.UseSqlServer(database);
});
builder.Services.AddDbContext<AppIdentityDbContext>(opt =>
{
    var configuration = builder.Configuration;
    var database = configuration.GetConnectionString("DefaultConnection");
    opt.UseSqlServer(database);
});
builder.Services.AddIdentity<AppIdentityUser,AppIdentityRole>(opt =>
{
   opt.User.RequireUniqueEmail = true;
    opt.Password.RequiredLength = 6;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireDigit = false;
}).AddEntityFrameworkStores<AppIdentityDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddControllers();
//builder.Services.AddScoped <RoleManager<AppIdentityRole>>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ITableRepository, TableRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
builder.Services.AddScoped<IMenuItemServices, MenuItemServices>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<ITableServices, TableServices>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IOrderItemService, OrderItemServices>();
builder.Services.AddScoped<IAuthServices, AuthServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<ICafeInfoServices, CafeInfoServices>();
builder.Services.AddScoped<IReviewServices, ReviewServices>();
builder.Services.AddScoped<TokenHelpers>();

builder.Services.AddAutoMapper(typeof(GeneralMapping).Assembly);

builder.Services.AddValidatorsFromAssemblyContaining<CreateCategoryDto>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateCategoryDto>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateMenuItemDto>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateMenuItemDto>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateTableDto>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateTableDto>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateOrderDto>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateOrderDto>(); 
builder.Services.AddValidatorsFromAssemblyContaining<CreateOrderItemDto>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateOrderItemDto>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateCafeInfoDto>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateCafeInfoDto>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateReviewDto>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateReviewDto>();

builder.Services.AddOpenApi();

//jwt yaplandrlmas
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();


// Serilog config
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();



builder.Services.AddSingleton<Serilog.ILogger>(Log.Logger);
builder.Host.UseSerilog();
builder.Services.AddHttpContextAccessor();

builder.Services.AddMemoryCache();
builder.Services.Configure<IpRateLimitOptions>(
    builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.AddInMemoryRateLimiting();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

var app = builder.Build();

builder.Services.AddEndpointsApiExplorer();

app.MapScalarApiReference(
    opt =>
    {
        opt.Title = "KafeAPI API v1";
        opt.Theme = ScalarTheme.BluePlanet;
        opt.DefaultHttpClient = new(ScalarTarget.Http, ScalarClient.Http11);
    });

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseIpRateLimiting();

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<SerilogMiddleware>();

app.MapControllers();

app.Run();
