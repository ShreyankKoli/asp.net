namespace Relationships.DTO
{
    public class TeacherCoursesDTO
    {
        public string? CourseName { get; set; }

        public int? TeacherId { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}

namespace Relationships.DTO
{
    public class TeacherCoursesDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<string>? CourseNames { get; set; } // List of courses
    }
}
