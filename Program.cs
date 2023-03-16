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

builder.Services.AddScoped<IRepositoryAppointment, RepositoryAppointment>();//every object will get a new instance

var app = builder.Build();

app.UseStaticFiles();  //serving static content from wwwroot

app.MapRazorPages();// map razor pages

app.MapDefaultControllerRoute(); //maping the home page

SeedData.PopulateDatabase(app); //populate the database with data

app.Run();
