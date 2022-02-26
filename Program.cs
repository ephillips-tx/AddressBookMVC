using AddressBookMVC.Data;
using AddressBookMVC.Services;
using AddressBookMVC.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// new code

var debug = DataUtility.GetConnectionString(builder.Configuration);
Trace.WriteLine(debug);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    
    options.UseNpgsql(DataUtility.GetConnectionString(builder.Configuration));
});

builder.Services.AddScoped<IImageService, BasicImageService>();
// end new code

var app = builder.Build();

//new code
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
//end new code

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