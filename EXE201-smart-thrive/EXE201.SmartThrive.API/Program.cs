using System.Text;
using System.Text.Json.Serialization;
using EXE201.SmartThrive.API.Registrations;
using EXE201.SmartThrive.Data;
using EXE201.SmartThrive.Data.Context;
using EXE201.SmartThrive.Domain.Configs.Mappings;
using EXE201.SmartThrive.Domain.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// builder.WebHost.ConfigureKestrel(options =>
// {
//     options.ListenLocalhost(6789); // Set the HTTP port
// });

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.AddDbContext<STDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SmartThrive"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddCustomRepositories();
builder.Services.AddCustomServices();

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = true;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetValue<string>("JWT:Token") ?? string.Empty)),
            ClockSkew = TimeSpan.Zero
        };

        options.Configuration = new OpenIdConnectConfiguration();
    });

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseSwaggerUI(c =>
    //{
    //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    //    c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    //});

    app.UseReDoc(options =>
    {
        options.DocumentTitle = "SmartThrive API Documentation";
        options.SpecUrl = "/swagger/v1/swagger.json";
    });
}

app.UseMiddleware<RequestTokenUserMiddleware>();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<STDbContext>();
    DummyData.SeedDatabase(context);
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();