using Microsoft.EntityFrameworkCore;
using Products_Web.Data;
using Products_Web.Repositories;
using Products_Web.Repositories.Interfaces;
using Products_Web.Services;
using Products_Web.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Products_Web.Data.Entities;
using Trainers_Web.Services;
using Workouts_Web.Services;
using Diets_Web.Services;
using Exercises_Web.Services;
using PushUps_Web.Services;
using Squats_Web.Services;
using PullUps_Web.Services;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("ApplicationContextConnectionString") ??
    throw new InvalidDataException("Connection string ApplicationContextConnectionString is not found");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationContext>(context => 
    context
    .UseLazyLoadingProxies()
    .UseMySQL(connectionString));

builder.Services.AddIdentity<User, IdentityRole>(options => 
{
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequiredLength = 4;
})
    .AddEntityFrameworkStores<ApplicationContext>();


#region Service/Repository
builder.Services.AddScoped<ITrainerRepository, TrainerRepository>();
builder.Services.AddScoped<ITrainerService, TrainerService>();

builder.Services.AddScoped<IPushUpRepository, PushUpRepository>();
builder.Services.AddScoped<IPushUpService, PushUpService>();

builder.Services.AddScoped<IPullUpRepository, PullUpRepository>();
builder.Services.AddScoped<IPullUpService, PullUpService>();

builder.Services.AddScoped<ISquatRepository, SquatRepository>();
builder.Services.AddScoped<ISquatService, SquatService>();

builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();
builder.Services.AddScoped<IWorkoutService, WorkoutService>();

builder.Services.AddScoped<IDietRepository, DietRepository>();
builder.Services.AddScoped<IDietService, DietService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
#endregion


builder.Services.AddRazorPages();

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

DataSeed.SeedUserRoles(app);
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
