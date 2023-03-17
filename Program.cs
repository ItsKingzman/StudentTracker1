using Microsoft.EntityFrameworkCore;
using System.Configuration;
using StudentTracker1.Interfaces;

// This creates an Application Builder object and passes command line arguments as parameters.
var builder = WebApplication.CreateBuilder(args);

// This adds Controllers and Views to the application builder's services.
builder.Services.AddControllersWithViews();

// This creates a Configuration Builder object, loads an application settings
// file from the file path specified and adds it to the Configuration Builder, 
// and builds the Configuration Builder's configuration.
var config = new ConfigurationBuilder() 
         .AddJsonFile("appsettings.json", optional: false) 
         .Build();

// This creates a service in the Configuration Builder to connect to a database
// using the ConnectionString stored in the configuration.
builder.Services.AddDbContext<StudentReportsContext>(opts => opts.UseSqlServer(config.GetSection("ConnectionString").Value));


// This adds a scoped instance of an IStudentReportRepository interface to the
// Configuration Builder's services.
builder.Services.AddScoped<IStudentReportRepository, StudentReportsRepository>();

// This builds the application.
var app = builder.Build();

// This checks if the application is in development.
if (!app.Environment.IsDevelopment())

// This adds Hypertext Strict Transport Security (HSTS) for additional security.
app.UseHsts();

// This enables HTTPS redirection for the application.
app.UseHttpsRedirection();

// This enables static file content to be served from the application.
app.UseStaticFiles();

// This configures the application to use the routing service.
app.UseRouting();

// This maps endpoints that are configured in the application.
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); 
});

// This enables the fallback functionality so that index.html is served when a route isn't found.
app.MapFallbackToFile("index.html");

// This runs the application.
app.Run(); 