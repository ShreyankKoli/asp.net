using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Relationships.DTO;
using Relationships.Models;

namespace Relationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManyToOneController : ControllerBase
    {
        private readonly RelationshipContext context;

        public ManyToOneController(RelationshipContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Teacher>>> GetAllAsync()
        {
            var data = await context.Teachers.Include(x => x.Courses).ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Teacher>>> GetByIdAsync(int id)
        {
            var data = await context.Teachers.Where(x => x.TeacherId == id).Include(x => x.Courses).FirstOrDefaultAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> PostAllAsync([FromBody] TeacherCoursesDTO teacherCoursesDTO)
        {
            if (teacherCoursesDTO == null)
            {
                return BadRequest("Invalid request data.");
            }

            var teacher = new Teacher
            {
                FirstName = teacherCoursesDTO.FirstName,
                LastName = teacherCoursesDTO.LastName,
                Courses = new List<Course>()
            };

            // Add course only if CourseName is provided
            if (!string.IsNullOrEmpty(teacherCoursesDTO.CourseName))
            {
                teacher.Courses.Add(new Course
                {
                    CourseName = teacherCoursesDTO.CourseName
                });
            }

            context.Teachers.Add(teacher);
            await context.SaveChangesAsync();

            return Ok("Teacher and course added successfully.");
        }

        [HttpPost]
        public async Task<IActionResult> PostAllAsync([FromBody] TeacherCoursesDTO teacherCoursesDTO)
        {
            if (teacherCoursesDTO == null || string.IsNullOrEmpty(teacherCoursesDTO.FirstName) || string.IsNullOrEmpty(teacherCoursesDTO.LastName))
            {
                return BadRequest("Invalid request data.");
            }

            var teacher = new Teacher
            {
                FirstName = teacherCoursesDTO.FirstName,
                LastName = teacherCoursesDTO.LastName,
                Courses = new List<Course>()
            };

            // Add multiple courses if provided
            if (teacherCoursesDTO.CourseNames != null && teacherCoursesDTO.CourseNames.Any())
            {
                foreach (var courseName in teacherCoursesDTO.CourseNames)
                {
                    teacher.Courses.Add(new Course
                    {
                        CourseName = courseName
                    });
                }
            }

            context.Teachers.Add(teacher);
            await context.SaveChangesAsync();

            return Ok("Teacher and courses added successfully.");
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacherAsync(int id, [FromBody] TeacherCoursesDTO dto)
        {
            if (dto == null || id <= 0)
            {
                return BadRequest("Invalid teacher data.");
            }

            var teacher = await context.Teachers
                .Include(t => t.Courses)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (teacher == null)
            {
                return NotFound("Teacher not found.");
            }

            // Update teacher details
            teacher.FirstName = dto.FirstName;
            teacher.LastName = dto.LastName;

            // Update courses (Handling CourseName updates)
            if (!string.IsNullOrEmpty(dto.CourseName))
            {
                var existingCourse = teacher.Courses.FirstOrDefault(c => c.CourseName == dto.CourseName);

                if (existingCourse == null)
                {
                    // Add new course if it does not exist
                    var newCourse = new Course
                    {
                        CourseName = dto.CourseName,
                        TeacherId = teacher.Id
                    };
                    teacher.Courses.Add(newCourse);
                }
            }

            await context.SaveChangesAsync();

            return Ok("Teacher and course updated successfully.");
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher>> DeleteAsync(int id)
        {
            var delete = await context.Teachers.FindAsync(id);
            if (delete == null)
            {
                throw new Exception("Invalid Id");
            }

            var delete1 = await context.Courses.Where(a => a.CourseId == id).FirstOrDefaultAsync();
            context.Courses.RemoveRange(delete1);
            context.Teachers.RemoveRange(delete);
            await context.SaveChangesAsync();
            return Ok("Deleted");
        }
    }
}
