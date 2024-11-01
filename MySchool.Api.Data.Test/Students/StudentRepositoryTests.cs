using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using MySchool.Api.Data.Models;
using MySchool.Api.Data.Students;

namespace MySchool.Api.Data.Test.Students
{
    public class StudentRepositoryTests
    {
        private Mock<SchoolDbContext> _schoolDbContext;
        private Mock<ILogger<StudentRepository>> _logger;
        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<StudentRepository>>();
            _schoolDbContext = new Mock<SchoolDbContext>();
        }

        [Test]
        public void Test_GetStudent_Success()
        {
            //Arrange
            string studentId = "f5701b30-5efa-433a-1be8-08dcf928f5cf";
            List<Student> initialData = new()  
            {
                new() 
                {
                    Id = new Guid(studentId), 
                    Name = "Deepak"
                }
            };
            var options = new DbContextOptionsBuilder<SchoolDbContext>()
                                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                .Options;
            using var context = new SchoolDbContext(options);
            context.Students.AddRange(initialData);
            context.SaveChanges();

            StudentRepository studentRepository = new(_logger.Object, context);

            //Act
            var response = studentRepository.GetStudent(new Guid(studentId));
            var result = response.Result;

            //Assert
            Assert.That(result?.Id.ToString(), Is.EqualTo(studentId));
        }
    }
}
