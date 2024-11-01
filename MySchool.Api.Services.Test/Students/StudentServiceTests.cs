using Microsoft.Extensions.Logging;
using Moq;
using MySchool.Api.Data.Models;
using MySchool.Api.Data.Students;
using MySchool.Api.Services.Students;

namespace MySchool.Api.Services.Test.Students
{
    public class StudentServiceTests
    {
        private Mock<IStudentRepository> _studentRepository;
        private Mock<ILogger<StudentService>> _logger;
        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<StudentService>>();
            _studentRepository = new Mock<IStudentRepository>();
        }

        [Test]
        public void Test_GetStudent_Success()
        {
            //Arrange
            Student? student = new()
            {
                Id = new Guid("f5701b30-5efa-433a-1be8-08dcf928f5cf")
            };
            _studentRepository.Setup(ss => ss.GetStudent(It.IsAny<Guid>()))
                           .Returns(Task.FromResult(student));
            StudentService studentService = new(_logger.Object, _studentRepository.Object);

            //Act
            var response = studentService.GetStudent(new Guid());
            var result = response.Result;

            //Assert
            Assert.That(result?.Id.ToString(), Is.EqualTo("f5701b30-5efa-433a-1be8-08dcf928f5cf"));
        }
    }
}
