using BlazorASG;
using BlazorASG.Application_Layer.Interfaces;
using BlazorASG.Application_Layer.Repositories;
using BlazorASG.Application_Layer.Use_Cases.Auth;
using BlazorASG.Data;
using CardShopping.Web.Token;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Services;
using Blazorise.Captcha.ReCaptcha;
using Blazorise;
using BlazorASG.Nswag;
using ApexCharts;
using BlazorASG.VitsModel;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Shared.Enums;
using Shared.Settings;
using Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Infrastructure.DataSource.ApiClientFactory;
using System.Configuration;
using BlazorASG.Token;

var builder = WebApplication.CreateBuilder(args);

string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial catalog=MDB_Use;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


// Add services to the container.  


var jwtSettings = builder.Configuration.GetSection("JWTSettings").Get<JWTSettings>();
builder.Services.AddSingleton<JWTSettings>(jwtSettings);


/////////////////////////////////////////////////////

builder.Services.InstallSharedConfigServices();
builder.Services.InstallInfrastructureConfigServices(configuration: builder.Configuration);
builder.Services.InstallApplicationConfigServices();




///////////////////////////////////////////////////

builder.Services.AddDbContext<UseDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});


builder.Services.AddHttpContextAccessor();
//builder.Services.AddScoped<IUserClaimsHelper, UserClaimsHelper>();

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



builder.Services.AddScoped<BlazorASG.Nswag.ClientFactory>();

/////////////////////////////////////////





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

 
////////////////////////////////////////
builder.Services.AddSingleton<ILoggerService,ConsoleLoggerService>();
builder.Services.AddScoped<IRAuth,RepostryAuth>();
builder.Services.AddScoped<CreateLogin>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<AuthCheckedService>();
/////////////////////
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
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddMudServices();
builder.Services.AddScoped<ProtectedSessionStorage>();

builder.Services.AddTransient<Auth>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
     .AddRoles<IdentityRole>()
     .AddRoleManager<RoleManager<IdentityRole>>()
     .AddSignInManager<SignInManager<IdentityUser>>()
     .AddUserManager<UserManager<IdentityUser>>()
    .AddEntityFrameworkStores<UseDbContext>();



builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddScoped<SessionManger>();



builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseAuthentication();
//app.UseAuthorization();


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication(); 
app.UseAuthorization();

app.UseRouting();
app.UseSession();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
await ATTK.Load();
app.Run();
