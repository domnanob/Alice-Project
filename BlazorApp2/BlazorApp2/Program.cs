using BlazorApp2;
using BlazorApp2.Components;
using BlazorApp2.Models;
using BlazorApp2.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;

    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 10000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.Cookie.Name = "auth_token";
    options.LoginPath = "/account/login";
    options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
    options.AccessDeniedPath = "/account/access-denied";
});
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();


builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddDbContext<AppDbContext>(c =>
    c.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IClubService, ClubService>();
builder.Services.AddScoped<IModelService<User>, UserService>();
builder.Services.AddScoped<IModelService<Role>, RoleService>();
builder.Services.AddScoped<IModelService<Test>, TestService>();
builder.Services.AddScoped<IModelService<TestCase>, TestCasesService>();
builder.Services.AddScoped<IModelService<StudentTest>, StudentTestService>();
builder.Services.AddSingleton<IBreadcrumbService, BreadcrumbService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode();

app.Run();
