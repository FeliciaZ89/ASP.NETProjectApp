using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(x => x.LowercaseUrls= true);
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddDefaultIdentity<UserEntity>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.Password.RequireUppercase = true;
    x.Password.RequireDigit = true;
    x.Password.RequireNonAlphanumeric = true;
    x.Password.RequireLowercase = true;

}).AddEntityFrameworkStores<DataContext>();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/signin";
    x.LogoutPath = "/signout";
    x.AccessDeniedPath = "/denied";

    x.Cookie.HttpOnly = true;
    x.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    x.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    x.SlidingExpiration = true;
});

builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<FeatureRepository>();
builder.Services.AddScoped<FeatureItemRepository>();
builder.Services.AddScoped<LightDarkSliderRepository>();
builder.Services.AddScoped<ToolsRepository>();
builder.Services.AddScoped<ToolsItemRepository>();

builder.Services.AddScoped<AddressManager>();
builder.Services.AddScoped<FeatureService>();
builder.Services.AddScoped<LightDarkSliderService>();
builder.Services.AddScoped<ToolsService>();

//builder.Services.AddAuthentication("AuthCookie").AddCookie("AuthCookie", x =>
//{
//    x.LoginPath = "/signin";
//    x.ExpireTimeSpan = TimeSpan.FromMinutes(60);


//});



var app = builder.Build();


//if (!app.Environment.IsDevelopment())
//{
    app.UseExceptionHandler("/Error");
app.UseStatusCodePagesWithReExecute("/Error", "?statusCode={0}");
app.UseHsts();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
