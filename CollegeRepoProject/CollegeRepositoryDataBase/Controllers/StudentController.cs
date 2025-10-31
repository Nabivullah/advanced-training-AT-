using CollegeRepositoryDataBase.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollegeRepositoryDataBase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IstudentRepo<Models.Student> _studentRepo;

        public StudentController(IstudentRepo<Models.Student> studentRepo)
        {
            _studentRepo = studentRepo;
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentRepo.GetAllAsync();
            return Ok(students);
        }


        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentRepo.GetByIdAsync(id);
            if (student == null)
                return NotFound($"Student with ID {id} not found.");

            return Ok(student);
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetStudentByName(string name)
        {
            var student = await _studentRepo.GetByNameAsync(name);
            if (student == null)
                return NotFound($"Student with Name {name} not found.");

            return Ok(student);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost("Add")]
        public async Task<IActionResult> AddStudent([FromBody] Models.Student student)
        {
            if (student == null)
                return BadRequest("Invalid student data.");

            var addedStudent = await _studentRepo.CreateAsync(student); 
            return Ok(addedStudent);
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Models.Student student)
        {
            if (student == null || id != student.StudentId)
                return BadRequest("Student ID mismatch or invalid data.");

            var updatedStudent = await _studentRepo.UpdateAsync(id,student);
            if (updatedStudent == null)
                return NotFound($"Student with ID {id} not found.");

            return Ok(updatedStudent);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var deleted = await _studentRepo.DeleteAsync(id);
            if (!deleted)
                return NotFound($"Student with ID {id} not found.");

            return Ok(new { message = $"Student with ID {id} deleted successfully." });
        }
    }
}
