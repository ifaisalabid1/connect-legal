using ConnectLegal.Data;
using ConnectLegal.Entities;
using ConnectLegal.Interfaces;
using ConnectLegal.Mapping;
using ConnectLegal.Repositories;
using ConnectLegal.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<ILawFirmRepository, LawFirmRepository>();
builder.Services.AddScoped<ILawyerRepository, LawyerRepository>();

builder.Services.AddScoped<ILawFirmService, LawFirmService>();
builder.Services.AddScoped<ILawyerService, LawyerService>();


builder.Services.AddOpenApi();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
}

app.Run();
