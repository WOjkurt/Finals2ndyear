using JwtAuthDemo.Models;
using JwtAuthDemo.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure PostgreSQL DbContext with Npgsql
builder.Services.AddNpgsql<Appdatacontext>("Host=localhost;Port=5432;Database=Mydb;Username=postgres;Password=12345");

// Register your JWT service
builder.Services.AddScoped<JwtService>();

// Configure JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourNewSuperSecretKey0123456789!"))
        };
    });

// Add authorization services
builder.Services.AddAuthorization();

// Configure session services
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable session before authentication
app.UseSession();

// Custom middleware to check session timeout (optional)
app.Use(async (context, next) =>
{
    var sessionTimeout = context.Session.GetString("SessionTimeout");

    if (!string.IsNullOrEmpty(sessionTimeout) && sessionTimeout == "7Days")
    {
        context.Session.SetString("CustomTimeout", "7Days");
    }

    await next();
});

// Authentication & Authorization middleware
app.UseAuthentication();
app.UseAuthorization();

// Map controller routes (endpoints)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

// Run the app
app.Run();
