namespace MySchool.Api.Data.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? Age { get; set; }
        public Guid? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
    }
}
