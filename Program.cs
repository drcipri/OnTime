var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();//add mvc service

builder.Services.AddRazorPages(); //add razor pages service

var app = builder.Build();

app.UseStaticFiles();  //serving static content from wwwroot

app.MapRazorPages();// map razor pages

app.MapDefaultControllerRoute(); //maping the home page

app.Run();
