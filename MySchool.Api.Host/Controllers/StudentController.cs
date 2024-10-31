using Microsoft.AspNetCore.Mvc;
using MySchool.Api.Data.Models;
using MySchool.Api.Services.Students;

namespace MySchool.Api.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;
        public StudentController(ILogger<StudentController> logger,
                                    IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Student> students = await _studentService.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            Student? student = await _studentService.GetStudent(id);
            if (student is not null)
            {
                return Ok(student);
            }
            _logger.LogInformation("No student found with id: {id}", id);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Student student)
        {
            Student? newStudent = await _studentService.CreateStudent(student);
            if (newStudent is not null)
            {
                return Ok(newStudent);
            }
            _logger.LogInformation("Error creating student with name: {name}", student.Name);
            return BadRequest();
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] Student student)
        {
            Student? newStudent = await _studentService.UpdateStudent(student);
            if (newStudent is not null)
            {
                return Ok(newStudent);
            }
            _logger.LogInformation("No student found with id: {id}", student.Id);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            Student? student = await _studentService.DeleteStudent(id);
            if (student is not null)
            {
                return Ok(student);
            }
            _logger.LogInformation("No student found with id: {id}", id);
            return NotFound();
        }
    }
}
