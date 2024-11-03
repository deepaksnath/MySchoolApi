using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using MySchool.Api.Data;
using MySchool.Api.Data.Departments;
using MySchool.Api.Data.Students;
using MySchool.Api.Services.Departments;
using MySchool.Api.Services.Students;
using Serilog;

namespace MySchool.Api.Host.Extensions
{
    public static class RegisterServiceDependencies
    {
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {
            //DB Context
            var config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false)
                    .Build();
            var CONNECTION_STRING = config.GetConnectionString("MySchoolDbConnection");
            var DB_HOST = Environment.GetEnvironmentVariable("DB_HOST");
            var DB_NAME = Environment.GetEnvironmentVariable("DB_NAME");
            var DB_SA_PASSWORD = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
            CONNECTION_STRING = string.Format(CONNECTION_STRING, DB_HOST, DB_NAME, DB_SA_PASSWORD);

            builder.Services.AddDbContextPool<SchoolDbContext>(
                options => options.UseSqlServer(CONNECTION_STRING));

            //Global Exception Handling
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();

            //Logging - Serilog
            var logger = new LoggerConfiguration()
                            .ReadFrom.Configuration(builder.Configuration)
                            .CreateLogger();
            builder.Logging.AddSerilog(logger);
            builder.Host.UseSerilog((ctx, conf) =>
            {
                conf.ReadFrom.Configuration(ctx.Configuration);
            });

            //Azure AD Auth
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                            .AddMicrosoftIdentityWebApi(builder.Configuration);
            //CORS
            builder.Services.AddCors();

            //App Services
            builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddTransient<IDepartmentService, DepartmentService>();
            builder.Services.AddTransient<IStudentRepository, StudentRepository>();
            builder.Services.AddTransient<IStudentService, StudentService>();

            return builder;
        }
    }
}
