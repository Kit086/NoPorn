
using Microsoft.EntityFrameworkCore;
using NoPorn.Mvc.ApplicationHelper;
using NoPorn.Mvc.ApplicationService;
using NoPorn.Mvc.Models;
using NoPorn.Mvc.Repositories;
using NoPorn.Mvc.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite("Data Source=./noporn.db"));
#region Repositories
builder.Services.AddScoped<IGirlRepository, GirlRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
#endregion
#region Services
builder.Services.AddScoped<IImageService, ImageService>();
#endregion
#region ApplicationServices
builder.Services.AddScoped<IImageAppService, ImageAppService>();
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
