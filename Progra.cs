using GiveAID.Data;
using GiveAID.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ============================================================
// SERVICE CONFIGURATION
// All dependency injection is configured here before building the app.
// ============================================================

// Configure SQLite database context
// Connection string is read from appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Configure cookie-based authentication
// This replaces ASP.NET Core Identity with a simpler custom approach
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "GiveAIDAuth";           // Cookie name
        options.LoginPath = "/Account/Login";           // Redirect here if not logged in
        options.LogoutPath = "/Account/Logout";         // URL for logging out
        options.AccessDeniedPath = "/Account/AccessDenied"; // Redirect here if unauthorized
        options.ExpireTimeSpan = TimeSpan.FromDays(7);  // Cookie valid for 7 days
        options.SlidingExpiration = true;               // Reset expiration on each request
    });

// Add MVC controllers with views
builder.Services.AddControllersWithViews();

// Register custom services for dependency injection
builder.Services.AddScoped<EmailService>();

// Build the application
var app = builder.Build();

// ============================================================
// MIDDLEWARE PIPELINE
// Order matters! Each middleware processes requests in order.
// ============================================================

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Serve static files (CSS, JS, images) from wwwroot/
app.UseStaticFiles();

app.UseRouting();

// Authentication must come before Authorization
app.UseAuthentication();
app.UseAuthorization();

// Default route: Controller=Home, Action=Index, optional id
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// ============================================================
// DATABASE INITIALIZATION
// Creates the database and seeds initial data on first run.
// ============================================================
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        // Create database if it doesn't exist and apply migrations
        context.Database.Migrate();
        // Seed initial data (admin account, causes, partners, etc.)
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while initializing the database.");
    }
}

app.Run();
