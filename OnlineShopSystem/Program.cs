using Domain.Configration.EntitiesProperties;
using Microsoft.EntityFrameworkCore;
using Presentation.Config.ConfigurationService;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using Presentation.Configration.Configrations;
using Microsoft.AspNetCore.Http.Features;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.HttpOverrides;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using EDUHuB.API.Middleware;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var Configuration = builder.Configuration;


//Add basics Configuration
builder.Services.AddControllers();//for using controller in API
builder.Services.AddCors();//to fix cors with angular
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

//add connection with database
string StringConnection = Configuration["Connection:DatabaseConnection"];
builder.Services.AddDbContext<AppDbContext>(optionsBuilder => {
    optionsBuilder.UseSqlServer(StringConnection);
});


builder.Services.AddEndpointsApiExplorer();

//Add swagger configuration
builder.Services.AddSwaggerDocumentation();

builder.Services.AddControllers().AddNewtonsoftJson(options => {
    options.SerializerSettings.ContractResolver = null;
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;//to ignore circle refrence
});


//Add Identity User
builder.Services.AddIdentity<User, Role>()
              .AddEntityFrameworkStores<AppDbContext>()
              .AddDefaultTokenProviders();

//add Option to Identity
builder.Services.Configure<IdentityOptions>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = false;
});


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScopedAutoMapper();
builder.Services.AddScopedService();
builder.Services.AddScopedRepository();

//Configuration on json returned
builder.Services.Configure<FormOptions>(options =>
{
    options.ValueLengthLimit = int.MaxValue;
    options.MultipartBodyLengthLimit = long.MaxValue;
    options.MultipartBoundaryLengthLimit = int.MaxValue;
    options.MultipartHeadersCountLimit = int.MaxValue;
    options.MultipartHeadersLengthLimit = int.MaxValue;
});


var key = Encoding.UTF8.GetBytes(Configuration["Keys:HashingKey"]);


//JWT Configuration
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(x => {
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = "issuer",
        ValidAudience = "audience",
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateLifetime = false,
        SaveSigninToken = true,
        ValidateAudience = true,
        ClockSkew = TimeSpan.Zero,
        RequireSignedTokens = false
    };
});



builder.Services.AddAuthorization(
    options =>
    {
        options.AddPolicy("Authenticated", policy => policy.RequireAuthenticatedUser());
    });

builder.Services.AddAuthenticationCore();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddMemoryCache();

var app = builder.Build();
IWebHostEnvironment env = app.Environment;
// Configure the HTTP request pipeline.
{
    app.UseSwagger();
    app.UseSwaggerUI();
    if (false)
        app.UseDeveloperExceptionPage();
}

app.UseCors(builder => builder
              .SetIsOriginAllowed(origin => true)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials());


app.UseTokenManagerMiddleware();
app.UseErrorHandlerMiddleware();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseSession();


app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor |
    ForwardedHeaders.XForwardedProto
});


app.UseHttpsRedirection();

app.UseSwaggerDocumentation();


app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Files")),
    RequestPath = "/Files"
});

app.MapControllers();

app.Run();
