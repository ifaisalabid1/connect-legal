using System.Text;
using ConnectLegal.Data;
using ConnectLegal.Entities;
using ConnectLegal.Interfaces;
using ConnectLegal.Mapping;
using ConnectLegal.Models;
using ConnectLegal.Repositories;
using ConnectLegal.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = false;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();


var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(jwtSettings);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]!))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdmin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("RequireLawyer", policy => policy.RequireRole("Lawyer"));
    options.AddPolicy("RequireAdminOrLawyer", policy =>
        policy.RequireRole("Admin", "Lawyer"));
});

builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<ILawFirmRepository, LawFirmRepository>();
builder.Services.AddScoped<ILawyerRepository, LawyerRepository>();

builder.Services.AddScoped<ILawFirmService, LawFirmService>();
builder.Services.AddScoped<ILawyerService, LawyerService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
        {
            policy.WithOrigins("http://localhost:5173");
        });
});

builder.Services.AddOpenApi();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.UseExceptionHandler("/Error");

app.UseHsts();

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
