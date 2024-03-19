using bmtqs_assessment.Models;
using bmtqs_assessment.Services.Interfaces;
using bmtqs_assessment.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Application Settings file as we need the configuration
builder.Configuration.AddJsonFile("appsettings.json", optional: false);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<DatabaseConnectionModel>(builder.Configuration.GetSection("Database"));

// Add custom services
builder.Services.AddSingleton<IDBConnectionService, DBConnectionService>();
builder.Services.AddSingleton<IContactDatabaseService, ContactDatabaseService>();

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
