using CollegeRepositoryDataBase.Models;
using CollegeRepositoryDataBase.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollegeRepositoryDataBase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class CourseController : ControllerBase
    {
        private readonly IstudentRepo<Models.Course> _courseRepo;

        public CourseController(IstudentRepo<Models.Course> courseRepo)
        {
            _courseRepo = courseRepo;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _courseRepo.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _courseRepo.GetByIdAsync(id);
            if (student == null)
                return NotFound($"Course with ID {id} not found.");

            return Ok(student);
        }

        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetCourseByName(string name)
        {
            var student = await _courseRepo.GetByNameAsync(name);
            if (student == null)
                return NotFound($"Course with Name {name} not found.");

            return Ok(student);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddStudent([FromBody] Models.Course student)
        {
            if (student == null)
                return BadRequest("Invalid Course data.");

            var addedStudent =await _courseRepo.CreateAsync(student);
            return Ok(addedStudent);
        }


        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Models.Course course)
        {
            if (course == null || id != course.CourseId)
                return BadRequest("Course ID mismatch.");

            course.Students = null; // ✅ Prevent EF tracking issues

            var updatedCourse = await _courseRepo.UpdateAsync(id, course);
            if (updatedCourse == null)
                return NotFound($"Course with ID {id} not found.");

            return Ok(updatedCourse);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var deletedStudent =await _courseRepo.DeleteAsync(id);
            if (deletedStudent == null)
                return NotFound($"Course with ID {id} not found.");

            return Ok(deletedStudent);
        }

    }
}
