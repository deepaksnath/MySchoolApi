using Microsoft.Extensions.Logging;
using MySchool.Api.Data.Models;

namespace MySchool.Api.Data.Departments
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ILogger<DepartmentRepository> _logger;
        private readonly SchoolDbContext _dbContext;

        public DepartmentRepository(
            ILogger<DepartmentRepository> logger,
            SchoolDbContext dBContext)
        {
            _logger = logger;
            _dbContext = dBContext;
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return _dbContext.Departments;
        }

        public async Task<Department?> GetDepartment(Guid id)
        {
            return await _dbContext.Departments.FindAsync(id);
        }

        public async Task<Department?> CreateDepartment(Department department)
        {
            await _dbContext.Departments.AddAsync(department);
            _dbContext.SaveChanges();
            return department;
        }

        public async Task<Department?> UpdateDepartment(Department department)
        {
            Department? existingDepartment = await _dbContext.Departments.FindAsync(department.Id);
            if (existingDepartment is not null)
            {
                _dbContext.Entry(existingDepartment).CurrentValues.SetValues(department);
                _dbContext.SaveChanges();
                return department;
            }
            return null;
        }

        public async Task<Department?> DeleteDepartment(Guid id)
        {
            Department? existingDepartment = await _dbContext.Departments.FindAsync(id);
            if (existingDepartment is not null)
            {
                _dbContext.Departments.Remove(existingDepartment);
                _dbContext.SaveChanges();
            }
            return existingDepartment;
        }
    }
}
