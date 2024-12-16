using LAHJA;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using MudBlazor;
using MudBlazor.Services;
using Blazorise.Captcha.ReCaptcha;
using Blazorise;
using Infrastructure;
using Shared.Settings;
using Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Shared.Helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Shared.Models;
using LAHJA.Helpers.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();



// Add services to the container.  


var jwtSettings = builder.Configuration.GetSection("JWTSettings").Get<JWTSettings>();
builder.Services.AddSingleton<JWTSettings>(jwtSettings);


/////////////////////////////////////////////////////

builder.Services.InstallSharedConfigServices();
builder.Services.InstallInfrastructureConfigServices(configuration: builder.Configuration);
builder.Services.InstallApplicationConfigServices();
builder.Services.InstallBlazorAppConfigServices();

builder.Services.Configure<ReCaptchaSettings>(builder.Configuration.GetSection("ReCaptchaSettings"));
builder.Services.AddOptions<ReCaptchaSettings>().BindConfiguration("ReCaptchaSettings");

///////////////////////////////////////////////////


builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserClaimsHelper, UserClaimsHelper>();

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
    };
});


///////////////////////////////////////////////////////TODO
builder.Services.AddAuthentication(options => {
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options => {
    options.LoginPath = "/login";
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.Strict;
});
//builder.Services.AddScoped<AuthenticationStateProvider, AppCustomAuthenticationStateProvider>();
builder.Services.AddScoped<AppCustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider =>
    provider.GetRequiredService<AppCustomAuthenticationStateProvider>());

//builder.Services.AddScoped<AppCustomAuthenticationStateProvider>();
builder.Services.AddScoped<IAppUserClaimsHelper, AppUserClaimsHelper>();


builder.Services.AddAuthorization();





builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBlazoriseGoogleReCaptcha(reCaptchaOptions =>
    {
        reCaptchaOptions.SiteKey = "dddddddgffee";
        //Set any other ReCaptcha options here...
    });

 


builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<ITokenService,TokenService>();

builder.Services.AddMudBlazorSnackbar(config =>
{
    config.PositionClass = Defaults.Classes.Position.BottomRight;
    config.PreventDuplicates = true;
    config.NewestOnTop = true;
    config.ShowCloseIcon = true;
    config.VisibleStateDuration = 5000; // „œ… ⁄—÷ «·—”«·… (3 ÀÊ«‰Ú)
    config.SnackbarVariant = Variant.Text; //  ’„Ì„ „„·Ê¡
});

//////////////////////////////////////////
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddScoped<ProtectedSessionStorage>();

builder.Services.AddDistributedMemoryCache();




builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});




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

app.UseAuthentication(); 
app.UseAuthorization();

app.UseRouting();
app.UseSession();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
//await ATTK.Load();
app.Run();
