//                _ooOoo_                       NAM MÔ A DI ?À PH?T !
//               o8888888o
//               88" . "88      Thí ch? con tên là Lê T?n L?c, d??ng l?ch hai m??i tháng m??i n?m 2003
//               (| -_- |)      
//                O\ = /O
//            ____/`---'\____         Con l?y chín ph??ng tr?i, con l?y m??i ph??ng ??t
//            .' \\| |// `.             Ch? Ph?t m??i ph??ng, m??i ph??ng ch? Ph?t
//           / \\||| : |||// \        Con ?n nh? Tr?i ??t ch? che, Thánh Th?n c?u ??
//         / _||||| -:- |||||- \    Xin nh?t tâm kính l? Hoàng thiên H?u th?, Tiên Ph?t Thánh Th?n
//           | | \\\ - /// | |              Giúp ?? con code s?ch ít bug
//         | \_| ''\---/'' | |           ??ng nghi?p vui v?, s?p quý t?ng l??ng
//         \ .-\__ `-` ___/-. /          S?c kho? d?i dào, ti?n vào nh? n??c
//       ___`. .' /--.--\ `. . __
//    ."" '< `.___\_<|>_/___.' >'"". NAM MÔ VIÊN THÔNG GIÁO CH? ??I T? ??I BI T?M THANH C?U KH? C?U N?N
//   | | : `- \`.;`\ _ /`;.`/ - ` : | |  QU?NG ??I LINH C?M QUÁN TH? ÂM B? TÁT
//     \ \ `-. \_ __\ /__ _/ .-` / /
//======`-.____`-.___\_____/___.-`____.-'======
//                `=---='
using EXE201.SmartThrive.API;
using EXE201.SmartThrive.API.HandleException;
using EXE201.SmartThrive.API.Registrations;
using EXE201.SmartThrive.Data;
using EXE201.SmartThrive.Data.Context;
using EXE201.SmartThrive.Domain.Configs;
using EXE201.SmartThrive.Domain.Middleware;
using EXE201.SmartThrive.Domain.Models;
using EXE201.SmartThrive.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;
using System.Text.Json.Serialization;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("starting server.");
    DotNetEnv.Env.Load();

    var builder = WebApplication.CreateBuilder(args);

    builder.Configuration.ConvertEnvToAppsettings();

    builder.Host.UseSerilog((context, loggerConfiguration) =>
    {
        loggerConfiguration.WriteTo.Console();
        loggerConfiguration.ReadFrom.Configuration(context.Configuration);
    });



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
        options.UseSqlServer(builder.Configuration.GetConnectionString("SmartThrive"),
            sqlOptions => sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    });


    builder.Services.AddAutoMapper(typeof(MappingProfile));

    builder.Services.AddCustomServices();
    builder.Services.AddCustomRepositories();

    builder.Services.AddHttpContextAccessor();
    //Register session type
    SessionService.RegisterProductType("Meeting", typeof(SessionService.SessionMeetingService));
    SessionService.RegisterProductType("Offline", typeof(SessionService.SessionOfflineService));
    SessionService.RegisterProductType("SelfLearn", typeof(SessionService.SessionSelfLearnService));

    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });

    #region Config_Authentication

    _ = builder.Services.AddAuthentication(options =>
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
        })
         .AddGoogle(options =>
         {
             IConfigurationSection googleAuthNSection = builder.Configuration.GetSection("Authentication:Google");

             options.ClientId = googleAuthNSection["ClientId"];
             options.ClientSecret = googleAuthNSection["ClientSecret"];
         });


    builder.Services.AddAuthorization();

    #endregion


    PayOsSettingModel.Instance = builder.Configuration.GetSection("PayOs")
                                                      .Get<PayOsSettingModel>();

    //Handle Exception
    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
    builder.Services.AddProblemDetails();
    var app = builder.Build();
    app.UseExceptionHandler(opt => { });
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
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
}
catch (Exception ex)
{
    Log.Fatal(ex, "server terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}