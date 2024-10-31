using Microsoft.Extensions.Logging;
using MySchool.Api.Data.Models;
using MySchool.Api.Data.Students;

namespace MySchool.Api.Services.Students
{
    public class StudentService : IStudentService
    {
        private readonly ILogger<StudentService> _logger;
        private readonly IStudentRepository _studentRepository;

        public StudentService(ILogger<StudentService> logger,
                                 IStudentRepository studentRepository)
        {
            _logger = logger;
            _studentRepository = studentRepository;
        }

        public Task<Student?> CreateStudent(Student student)
        {
            return _studentRepository.CreateStudent(student);
        }

        public Task<Student?> DeleteStudent(Guid id)
        {
            return _studentRepository.DeleteStudent(id);
        }

        public Task<IEnumerable<Student>> GetAllStudents()
        {
            return _studentRepository.GetAllStudents();
        }

        public Task<Student?> GetStudent(Guid id)
        {
            return _studentRepository.GetStudent(id);
        }

        public Task<Student?> UpdateStudent(Student student)
        {
            return _studentRepository.UpdateStudent(student);
        }
    }
}
