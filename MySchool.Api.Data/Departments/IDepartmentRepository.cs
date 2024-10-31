using MySchool.Api.Data.Models;

namespace MySchool.Api.Data.Departments
{
    public interface IDepartmentRepository
    {
        Task<Department?> GetDepartment(Guid id);
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<Department?> CreateDepartment(Department department);
        Task<Department?> UpdateDepartment(Department department);
        Task<Department?> DeleteDepartment(Guid id);
    }
}
