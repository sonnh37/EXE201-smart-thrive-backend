namespace EXE201.SmartThrive.API
{
    public static class EnvToAppsettings
    {
        public static void ConvertEnvToAppsettings(this IConfiguration Configuration)
        {
            Configuration["Domain"] = Environment.GetEnvironmentVariable("DOMAIN") + "/api/";
            Configuration["PayOs:ClientId"] = Environment.GetEnvironmentVariable("PAYOS_CLIENT_ID");
            Configuration["PayOs:ApiKey"] = Environment.GetEnvironmentVariable("PAYOS_API_KEY");
            Configuration["PayOs:CheckSumKey"] = Environment.GetEnvironmentVariable("PAYOS_CHECKSUM_KEY");
            Configuration["JWT:Token"] = Environment.GetEnvironmentVariable("JWT_TOKEN");
            Configuration["Authentication:Google:ClientId"] = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_ID");
            Configuration["Authentication:Google:ClientSecret"] = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_SECRET");

        }
    }
}
