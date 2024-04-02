using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using my.blog.site.Data;
using my.blog.site.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("MsSQLConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddIdentity<AppUsers, IdentityRole>(
    options =>
    {
        options.Password.RequiredUniqueChars = 0;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 8;
        options.Password.RequireLowercase = false;
    })
    .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
