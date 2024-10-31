using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySchool.Api.Data.Models;

namespace MySchool.Api.Data.Students
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ILogger<StudentRepository> _logger;
        private readonly SchoolDbContext _dbContext;

        public StudentRepository(
            ILogger<StudentRepository> logger,
            SchoolDbContext dBContext)
        {
            _logger = logger;
            _dbContext = dBContext;
        }
        public async Task<Student?> CreateStudent(Student student)
        {
            await _dbContext.Students.AddAsync(student);
            _dbContext.SaveChanges();
            return student;
        }

        public async Task<Student?> DeleteStudent(Guid id)
        {
            Student? existingStudent = await _dbContext.Students.FindAsync(id);
            if (existingStudent is not null)
            {
                _dbContext.Students.Remove(existingStudent);
                _dbContext.SaveChanges();
            }
            return existingStudent;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return _dbContext.Students
                             .Include(s => s.Department);
        }

        public async Task<Student?> GetStudent(Guid id)
        {
            return _dbContext.Students
                             .Include(i => i.Department)
                             .FirstOrDefault(x => x.Id == id);
        }

        public async Task<Student?> UpdateStudent(Student student)
        {
            Student? existingStudent = await _dbContext.Students.FindAsync(student.Id);
            if (existingStudent is not null)
            {
                _dbContext.Entry(existingStudent).CurrentValues.SetValues(student);
                _dbContext.SaveChanges();
                return student;
            }
            return null;
        }
    }
}
