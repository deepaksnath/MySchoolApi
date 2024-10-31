using MySchool.Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Api.Services.Departments
{
    public interface IDepartmentService
    {
        Task<Department?> GetDepartment(Guid id);
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<Department?> CreateDepartment(Department department);
        Task<Department?> UpdateDepartment(Department department);
        Task<Department?> DeleteDepartment(Guid id);
    }
}
