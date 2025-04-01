using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPITest.Model;
using WebAPITest.Repository;
using WebAPITest.Service;

namespace WebAPITest.Controllers
{
    [Route("api/teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }


        [HttpPost("create")]
        public async Task<ActionResult> AddTeacher([FromBody] Teacher teacher)
        {
            try
            {
                var teacherData = await _teacherService.CreateTeacherAsync(teacher);
                return Ok(new { message = $"Successfully added teacher", data = teacherData });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        [HttpGet()]
        public async Task<ActionResult<Teacher>> GetAllTeachers()
        {
            try
            {
                var teachers = await _teacherService.GetAllTeachersAsync();
                if (teachers == null)
                {
                    return NoContent();
                }
                return Ok(teachers);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTeacherById(int id)
        {
            var record = await _teacherService.GetTeachersByIdAsync(id);
            if (record == null)
            {
                return NotFound($"Teacher data with id {id} not found!!!");
            }
            return Ok(record);
        }

        [HttpPut()]
        public async Task<ActionResult<Teacher>> UpdateTeacherDataAsync(Teacher teacher)
        {
            var record = await _teacherService.UpdateTeacherDataAsync(teacher);
            if (record == null)
            {
                return NotFound($"Teacher data with id {teacher.Id}");
            }
            return Ok(new { message = "Successfully updated data", data = record });
        }

        [HttpPatch()]
        public async Task<ActionResult<Teacher>> PartialUpdateTeacherDataAsync(Teacher teacher)
        {
            var record = await _teacherService.PartialUpdateTeacherDataAsync(teacher);
            if (record == null)
            {
                return NotFound($"Teacher data with id {teacher.Id} not found");
            }
            return Ok(new { message = "Successfully updated data", data = record });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeacherAsync(int id)
        {
            var teacherId = await _teacherService.DeleteTeacherAsync(id);
            if (teacherId == null)
            {
                return NotFound($"Teacher data with id {id} not found");
            }
            return Ok(new { message = $"Successfully deleted teacher data with id {teacherId}"});
        }
    }
}
