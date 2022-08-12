using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Configuration.Mapper;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.DbContexts;
using DataAccessLayer.DbContexts.Abstract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models.MongoEntites;
using MongoDB.Driver;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthorization();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AptManagerDbContext>(x=>x.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:MsSql").Value));


// Mongo Server Conf

//builder.Services.AddSingleton<MongoClient>(x => new MongoClient("mongodb://localhost:27017"));

builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoSettings"));


//builder.Services.AddSingleton<ICreditCardInfoRepository, CreditCardInfoRepository>();

//builder.Services.AddSingleton<ICreditCardService, CreditCardService>();

builder.Services.AddSingleton<CreditCardService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();
builder.Services.AddScoped<IBuildingService, BuildingService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
