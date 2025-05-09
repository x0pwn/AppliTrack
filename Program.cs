using AppliTrack.Data;                   // ① bring in your DbContext
using Microsoft.EntityFrameworkCore;     // ② bring in EF Core extensions

var builder = WebApplication.CreateBuilder(args);

// configure SQLite using your connection string
builder.Services.AddDbContext<JobTrackerContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();

app.Run();
