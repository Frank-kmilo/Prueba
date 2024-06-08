using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Prueba.API.Data;
using Prueba.API.Data.Entities;
using Prueba.API.Helpers;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddIdentityCore<User>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.Password.RequiredUniqueChars = 0;
    x.Password.RequireLowercase = false;
    x.Password.RequireUppercase = false;
    x.Password.RequiredLength = 4;
    x.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<DataContext>();


void SeedDatabase(IWebHost host)//can be placed at the very bottom under app.Run()
{
    IServiceScopeFactory scopeFactory = host.Services.GetService<IServiceScopeFactory>();
    using (IServiceScope scope = scopeFactory.CreateScope())
    {
        SeedDb seeder = scope.ServiceProvider.GetService<SeedDb>();
        seeder.SeedAsync().Wait();
    }
}

builder.Services.AddTransient<SeedDb>();
builder.Services.AddScoped<IUserHelper, UserHelper>();


builder.Services.AddDbContext<DataContext>(x =>
{
    _ = x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    _ = app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    _ = app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
