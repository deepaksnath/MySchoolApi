using MySchool.Api.Data.Models;

namespace MySchool.Api.Data.Students
{
    public interface IStudentRepository
    {
        Task<Student?> GetStudent(Guid id);
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student?> CreateStudent(Student student);
        Task<Student?> UpdateStudent(Student student);
        Task<Student?> DeleteStudent(Guid id);
    }
}
