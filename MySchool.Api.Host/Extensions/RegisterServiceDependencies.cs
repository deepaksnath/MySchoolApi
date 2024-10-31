using Microsoft.EntityFrameworkCore;
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
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            //DB Context
            var config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false)
                    .Build();
            services.AddDbContextPool<SchoolDbContext>(
                options => options.UseSqlServer(config.GetConnectionString("MySchoolDbConnection")));
            
            //Global Exception Handling
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();

            //App Services
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IStudentService, StudentService>();

            return services;
        }
    }
}
