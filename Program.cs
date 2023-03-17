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
var app = builder.Build();

app.UseStaticFiles();  //serving static content from wwwroot

app.MapRazorPages();// map razor pages

app.MapDefaultControllerRoute(); //maping the home page

SeedData.PopulateDatabase(app); //populate the database with data

app.Run();
