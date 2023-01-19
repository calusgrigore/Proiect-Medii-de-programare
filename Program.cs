using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TelefoaneOnline.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});


// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Telefoane");
    options.Conventions.AllowAnonymousToPage("/Telefoane/Index");
    options.Conventions.AllowAnonymousToPage("/Telefoane/Details");
    options.Conventions.AuthorizeFolder("/Utilizatori", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Utilizatori", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Vandute", "AdminPolicy");
    options.Conventions.AuthorizePage("/Memorii/Delete", "AdminPolicy");
    options.Conventions.AuthorizePage("/Memorii/Edit", "AdminPolicy");
    options.Conventions.AuthorizePage("/Memorii/Create", "AdminPolicy");
    options.Conventions.AuthorizePage("/Categorii/Delete", "AdminPolicy");
    options.Conventions.AuthorizePage("/Categorii/Edit", "AdminPolicy");
    options.Conventions.AuthorizePage("/Categorii/Create", "AdminPolicy");
    options.Conventions.AuthorizePage("/Culori/Delete", "AdminPolicy");
    options.Conventions.AuthorizePage("/Culori/Edit", "AdminPolicy");
    options.Conventions.AuthorizePage("/Culori/Create", "AdminPolicy");
});

builder.Services.AddDbContext<TelefoaneOnlineContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TelefoaneOnlineContext") ?? throw new InvalidOperationException("Connection string 'TelefoaneOnlineContext' not found.")));
builder.Services.AddDbContext<LibraryIdentityContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TelefoaneOnlineContext") ?? throw new InvalidOperationException("Connection string 'TelefoaneOnlineContext' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
