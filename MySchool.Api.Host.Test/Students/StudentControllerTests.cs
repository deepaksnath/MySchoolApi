using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MySchool.Api.Data.Models;
using MySchool.Api.Host.Controllers;
using MySchool.Api.Services.Students;

namespace MySchool.Api.Host.Test.Students
{
    public class StudentControllerTests
    {

        private Mock<IStudentService> _studentService;
        private Mock<ILogger<StudentController>> _logger;
        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<StudentController>>();
            _studentService = new Mock<IStudentService>();
        }

        [Test]
        public void Get()
        {
            //Arrange
            Student? student = new()
            {
                Id = new Guid()
            };
            _studentService.Setup(ss => ss.GetStudent(It.IsAny<Guid>()))
                           .Returns(Task.FromResult(student));
            StudentController studentController = new(_logger.Object, _studentService.Object);

            //Act
            var response = studentController.Get(new Guid()); 
            var result = response.Result as OkObjectResult;

            //Assert
            Assert.That(result?.StatusCode, Is.EqualTo(200));
        }
    }
}