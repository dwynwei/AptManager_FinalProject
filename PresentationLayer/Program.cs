using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Configuration.Mapper;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.DbContexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Models.EmailEntities;
using Models.MongoEntites;
using MongoDB.Driver;
using System.Text;
using Hangfire;
using BackgroundJobs.Abstract;
using BackgroundJobs.Concrete;
using Models.CacheEntities;
using ServiceStack.Redis;
using Models.Entities;
using BusinessLayer.Helper;
using BusinessLayer.Helper.Abstract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthorization();

// Swagger Service with Token Option

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                          Enter 'Bearer' [space] and then your token in the text input below.
                          \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,

            },
            new List<string>()
        }
    });
});
   

builder.Services.AddDbContext<AptManagerDbContext>(x => x.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:MsSql").Value));

builder.Services.AddAuthorization();
builder.Services.AddControllers();

//builder.Services.AddAuthorization(opt =>
//{
//    opt.AddPolicy("ManagerAccess", policy =>
//    policy.RequireAssertion(context => context.User.IsInRole(UserRole.Manager.ToString())));

//    opt.AddPolicy("UserAccess", policy =>
//    policy.RequireAssertion(context => 
//        context.User.IsInRole(UserRole.User.ToString()) || 
//        context.User.IsInRole(UserRole.Manager.ToString())));
//});

// Mongo Server Conf
#region Mongo Conf
builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoSettings"));
#endregion

// Email Conf
#region Email Conf And Implementation
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<IMailService, MailService>();
#endregion

// Services
#region Services Implementation
builder.Services.AddSingleton<CreditCardService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();
builder.Services.AddScoped<IBuildingService, BuildingService>();
builder.Services.AddScoped<IHomeRepository, HomeOwnerRepository>();
builder.Services.AddScoped<IHomeOwnerService, HomeOwnerService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IHangFireJobService, HangFireJobService>();
builder.Services.AddTransient<IOutcomeCalculator, OutcomeCalculator>();
#endregion

// HangFire
#region HangFire Implementation
var hfDb = builder.Configuration.GetSection("ConnectionStrings:HangfireConnection").Value;

builder.Services.AddHangfire(conf => conf
.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
.UseSimpleAssemblyNameTypeSerializer()
.UseRecommendedSerializerSettings()
.UseSqlServerStorage(hfDb, new Hangfire.SqlServer.SqlServerStorageOptions
{
    CommandBatchMaxTimeout = TimeSpan.FromMinutes(3),
    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(3),
    QueuePollInterval = TimeSpan.Zero,
    UseRecommendedIsolationLevel = true,
    DisableGlobalLocks = true
}));

builder.Services.AddHangfireServer();

#endregion

// AutoMapper
#region AutoMapper Conf and Implementation
builder.Services.AddAutoMapper(conf =>
    {
        conf.AddProfile(new MapperProfile());
    });


    var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<BusinessLayer.Configuration.Auth.TokenOption>();
    builder.Services.AddAuthentication(opt =>
    {
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
    })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = tokenOptions.Issuer,
                ValidAudience = tokenOptions.Audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))
            };
        });
#endregion

// Redis Conf (Not Used in Any Services)
#region Redis Conf And Implementation
var redisConf = builder.Configuration.GetSection("RedisEndpointInfo").Get<RedisEndPointSettings>();

builder.Services.AddSingleton<RedisEndpoint>(opt =>
{
    return new RedisEndpoint
    {
        Host = redisConf.Endpoint,
        Port = redisConf.Port,
        Username = redisConf.Username,
        Password = redisConf.Password
    };
});
#endregion

var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();

    app.MapControllers();
    
    // Hangfire Endpoint 
    app.UseHangfireDashboard("/HfJob", new DashboardOptions());

    app.UseRouting();

    app.Run();
