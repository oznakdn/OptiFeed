using Microsoft.EntityFrameworkCore;
using OptiFeed.Persistence.Context;
using OptiFeed.Persistence.Repositories;
using Radzen;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<AppDbContext>(opt=> opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddMasaBlazor(options =>
//{
//    options.ConfigureTheme(theme =>
//    {
//        theme.Dark = true;
//    });
//});

builder.Services.AddMasaBlazor();

builder.Services.AddRadzenComponents();

builder.Services.AddScoped<IFeedRepository,FeedRepository>();
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
