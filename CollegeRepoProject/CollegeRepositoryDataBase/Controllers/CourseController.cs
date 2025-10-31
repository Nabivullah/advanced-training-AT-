using Microsoft.AspNetCore.Mvc;
using CollegeRepositoryDataBase.Repository;
using Microsoft.AspNetCore.Authorization;

namespace CollegeRepositoryDataBase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly IstudentRepo<Models.Course> _courseRepo;

        public CourseController(IstudentRepo<Models.Course> courseRepo)
        {
            _courseRepo = courseRepo;
        }
        [Authorize(Roles ="Admin,User")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _courseRepo.GetAllAsync();
            return Ok(students);
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _courseRepo.GetByIdAsync(id);
            if (student == null)
                return NotFound($"Course with ID {id} not found.");

            return Ok(student);
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetCourseByName(string name)
        {
            var student = await _courseRepo.GetByNameAsync(name);
            if (student == null)
                return NotFound($"Course with Name {name} not found.");

            return Ok(student);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("Add")]
        public async Task<IActionResult> AddStudent([FromBody] Models.Course student)
        {
            if (student == null)
                return BadRequest("Invalid Course data.");

            var addedStudent =await _courseRepo.CreateAsync(student);
            return Ok(addedStudent);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Models.Course student)
        {
            if (student == null || id != student.CourseId)
                return BadRequest("Course ID mismatch.");

            var updatedStudent = await _courseRepo.UpdateAsync(id,student);
            if (updatedStudent == null)
                return NotFound($"Course with ID {id} not found.");

            return Ok(updatedStudent);
        }



        [Authorize(Roles = "Admin")]
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
