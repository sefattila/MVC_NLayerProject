using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC_NLayerProject.BLL.ArticleService;
using MVC_NLayerProject.BLL.UserService;
using MVC_NLayerProject.CORE.Entities;
using MVC_NLayerProject.CORE.Repositories;
using MVC_NLayerProject.DAL.Contexts;
using MVC_NLayerProject.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DbContext
var conn = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection String Bulunamadý");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(conn);
    options.UseLazyLoadingProxies();
});

//Identity
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.SignIn.RequireConfirmedAccount = false;

    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;

}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

//AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Repository
builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<IAppUserRepository, AppUserRepository>();
builder.Services.AddTransient<IArticleRepository, ArticleRepository>();

//Service
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IArticleService, ArticleService>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
