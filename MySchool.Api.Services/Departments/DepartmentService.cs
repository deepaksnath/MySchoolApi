using Microsoft.Extensions.Logging;
using MySchool.Api.Data.Departments;
using MySchool.Api.Data.Models;

namespace MySchool.Api.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ILogger<DepartmentService> _logger;
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(ILogger<DepartmentService> logger,
                                 IDepartmentRepository departmentRepository)
        {
            _logger = logger;
            _departmentRepository = departmentRepository;
        }

        public Task<Department?> CreateDepartment(Department department)
        {
            return _departmentRepository.CreateDepartment(department);
        }

        public Task<Department?> DeleteDepartment(Guid id)
        {
            return _departmentRepository.DeleteDepartment(id);
        }

        public Task<IEnumerable<Department>> GetAllDepartments()
        {
            return _departmentRepository.GetAllDepartments();
        }

        public Task<Department?> GetDepartment(Guid id)
        {
            return _departmentRepository.GetDepartment(id);
        }

        public Task<Department?> UpdateDepartment(Department department)
        {
            return _departmentRepository.UpdateDepartment(department);
        }

    }
}
