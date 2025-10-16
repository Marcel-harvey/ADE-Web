using ADE_Web.Data;
using ADE_Web.Services.AppsBuiltService;
using ADE_Web.Services.BlogService;
using ADE_Web.Services.TechStackService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// 1. Use PostgreSQL from connection string (Neon)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                       ?? Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// 2. Add Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
    options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
});

// 3. Register scoped services
builder.Services.AddScoped<IAppsService, AppsService>();
builder.Services.AddScoped<ITechService, TechService>();
builder.Services.AddScoped<IBlogService, BlogService>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// 4. Apply migrations safely
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    try
    {
        db.Database.Migrate(); // auto-apply migrations
    }
    catch (Exception ex)
    {
        // Log to Azure App Service logs
        Console.WriteLine("Migration failed: " + ex.Message);
    }
}

// 5. Create Admin User
async Task CreateAdminUser(IApplicationBuilder app)
{
    using var scope = app.ApplicationServices.CreateScope();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var adminEmail = "marcel@ade.com";
    var adminPassword = "Admin123!";
    var adminRole = "Admin";

    if (!await roleManager.RoleExistsAsync(adminRole))
        await roleManager.CreateAsync(new IdentityRole(adminRole));

    var user = await userManager.FindByEmailAsync(adminEmail);
    if (user == null)
    {
        user = new IdentityUser { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
        await userManager.CreateAsync(user, adminPassword);
        await userManager.AddToRoleAsync(user, adminRole);
    }
}

await CreateAdminUser(app);

// 6. Middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Shows detailed errors in dev
}
else
{
    app.UseExceptionHandler("/Home/Error"); // Production error page
    app.UseHsts();
}


var defaultCulture = new CultureInfo("en-ZA");
defaultCulture.NumberFormat.NumberDecimalSeparator = ".";
defaultCulture.NumberFormat.CurrencyDecimalSeparator = ".";
defaultCulture.NumberFormat.NumberGroupSeparator = ",";
CultureInfo.DefaultThreadCurrentCulture = defaultCulture;
CultureInfo.DefaultThreadCurrentUICulture = defaultCulture;

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
