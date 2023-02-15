using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using SalesOrderManagement.Data.DBContext;
using SalesOrderManagement.Data.Repositories;
using SalesOrderManagement.Server.Infrastructure.Mapper;
using SalesOrderManagement.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SalesOrderDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SalesOrderDb") ?? throw new InvalidOperationException("Connection string 'SalesOrderDb' not found."
        ), b => b.MigrationsAssembly("SalesOrderManagement.Data")
    );
    options.EnableSensitiveDataLogging();
});


builder.Services.AddScoped<ISalesOrderService, SalesOrderService>();
builder.Services.AddScoped<ISalesOrderRepository, SalesOrderRepository>();



// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
} else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
