var courses = new List<Course>();
foreach (var courseName in teacherCoursesDTO.CourseNames)
{
    courses.Add(new Course { CourseName = courseName, TeacherId = teacher.TeacherId });
}
context.Courses.AddRange(courses);
await context.SaveChangesAsync();


var courses = teacherCoursesDTO.CourseNames.Select(courseName => new Course
{
    CourseName = courseName,
    TeacherId = teacher.TeacherId
}).ToList();

context.Courses.AddRange(courses);
await context.SaveChangesAsync();


var courses = new List<Course>();
teacherCoursesDTO.CourseNames.ForEach(courseName =>
{
    courses.Add(new Course { CourseName = courseName, TeacherId = teacher.TeacherId });
});

context.Courses.AddRange(courses);
await context.SaveChangesAsync();


var teacher = new Teacher
{
    FirstName = teacherCoursesDTO.FirstName,
    LastName = teacherCoursesDTO.LastName,
    Courses = teacherCoursesDTO.CourseNames.Select(courseName => new Course { CourseName = courseName }).ToList()
};

context.Teachers.Add(teacher);
await context.SaveChangesAsync();


