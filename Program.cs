using Microsoft.EntityFrameworkCore;
using OnTime.Models;
using OnTime.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OnTimeAppointmentsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("OnTimeAppointmentsDbContext"));
});

builder.Services.AddControllersWithViews();//add mvc service

builder.Services.AddRazorPages(); //add razor pages service

builder.Services.AddScoped<IRepositoryAppointment, RepositoryAppointment>();//each http request will get its own repository object
builder.Services.AddScoped<IRepositoryClassification, RepositoryClassification>();//each http request will get its own repository object
builder.Services.AddScoped<IRepositoryAppointmentsAudit, RepositoryAppointmentsAudit>();
var app = builder.Build();

app.UseStaticFiles();  //serving static content from wwwroot

app.MapRazorPages();// map razor pages

app.MapControllerRoute("home", "Home", new { Controller = "Home", action = "Index" });
app.MapControllerRoute("history", "History", new { Controller = "History", action = "AppointmentsHistory" });
app.MapControllerRoute("classification", "{classification}", new { Controller = "Home", action = "Index", appointmentsPage = 1 });
app.MapControllerRoute("pagination","{classification}/Page{appointmentsPage:int}", new {Controller = "Home", action = "Index"}); // :int -> is a constraint 
app.MapDefaultControllerRoute(); //maping the home page

SeedData.PopulateDatabase(app); //populate the database with data

app.Run();
