using ItemsAPI.Data;
using ItemsAPI.Repositories;
using ItemsAPI.Services;
using Microsoft.EntityFrameworkCore;
using static ItemsAPI.Data.Configurations;

var builder = WebApplication.CreateBuilder(args);

//add item context
builder.Services.AddDbContext<DenshiContext>(options =>
                options.UseSqlServer(Configuration.ConnectionString));

// Add application services and repositories.
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
