using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FalknerCountyJuvenileCourt.Data;
using FalknerCountyJuvenileCourt.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
var connectionString = builder.Configuration.GetConnectionString("CourtContext");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'CourtContext' not found.");
}

builder.Services.AddDbContext<CourtContext>(options =>
{
    options.UseSqlite("AZURE_SQL_CONNECTIONSTRING");
});

var options = new DbContextOptionsBuilder<CourtContext>()
    .UseSqlite("AZURE_SQL_CONNECTIONSTRING")
    .Options;

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDistributedMemoryCache();

// Add Identity services
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<CourtContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
   var services = scope.ServiceProvider;

   var context = services.GetRequiredService<CourtContext>();
   // context.Database.EnsureCreated();
  DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.Run();
