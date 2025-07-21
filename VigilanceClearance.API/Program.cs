using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;
using VigilanceClearance.API.Infrastructure;
using VigilanceClearance.API.Infrastructure.MiddleWare;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Services;
using VigilanceClearance.Infrastructure.Infrastructure.Identity;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.DbContexts;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
var timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH_mm");
var logFileName = $"Logs/log-{timestamp}.txt";

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File(
        path: logFileName,
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}"
    )
    .CreateLogger();
builder.Host.UseSerilog();
builder.Services.AddSwaggerGen(option =>
{
    //option.SupportNonNullableReferenceTypes();
    var jwtSecutiryschim = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Enter your JWT Access Token",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    option.AddSecurityDefinition("Bearer", jwtSecutiryschim);

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                jwtSecutiryschim, Array.Empty<string>()
            }
        });
}
);


builder.Services.AddDbContext<VCDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));

builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
            )
        };
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
    options.AddPolicy("UserPolicy", policy => policy.RequireRole("User"));
});


builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.Dependencies();


builder.Logging.ClearProviders();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI();




app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
