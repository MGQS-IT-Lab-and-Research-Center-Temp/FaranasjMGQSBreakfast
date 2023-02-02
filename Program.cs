using MGQSBreakfast.Context;
using MGQSBreakfast.Contracts.Repositories;
using MGQSBreakfast.Contracts.Services;
using MGQSBreakfast.Implementation.Repositories;
using MGQSBreakfast.Implementation.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseMySQL(builder.Configuration.GetConnectionString("ApplicationDBContext")));

// builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseMySQL("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MGQSBreakfastDB; Integrated Security=True"));

builder.Services.AddTransient<IBreakfastRepository, BreakfastRepository>();
builder.Services.AddTransient<IBreakfastService, BreakfastService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
