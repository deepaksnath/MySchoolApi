using Microsoft.AspNetCore.Mvc;
using MySchool.Api.Data.Models;
using MySchool.Api.Services.Departments;

namespace MySchool.Api.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly IDepartmentService _departmentService;
        public DepartmentController(ILogger<DepartmentController> logger,
                                    IDepartmentService departmentService)
        {
            _logger = logger;
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Department> departments = await _departmentService.GetAllDepartments();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            Department? department = await _departmentService.GetDepartment(id);
            if (department is not null)
            {
                return Ok(department);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Department department)
        {
            Department? newDepartment = await _departmentService.CreateDepartment(department);
            if (newDepartment is not null)
            {
                return Ok(newDepartment);
            }
            return BadRequest();
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] Department department)
        {
            Department? newDepartment = await _departmentService.UpdateDepartment(department);
            if (newDepartment is not null)
            {
                return Ok(newDepartment);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            Department? department = await _departmentService.DeleteDepartment(id);
            if (department is not null)
            {
                return Ok(department);
            }
            return NotFound();
        }
    }
}
