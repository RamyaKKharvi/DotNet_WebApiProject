using System.Net;
using Microsoft.AspNetCore.Mvc;
using WebAPITest.Model;
using WebAPITest.Service;

namespace WebAPITest.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("name")]
        public string MyName(string name, int id)
        {
            return _studentService.MyName(name) + " " + id;
        }

        [HttpGet("length/{id:minlength(5):maxlength(10):length(7)}")]
        public string Hello(string name, string id)
        {
            return "Hello" + " " + name + " " + id;
        }

        [HttpGet("min/max/{id:int:min(10):max(50)}")]
        public string Hello(string name, int id)
        {
            return name + " " + id;
        }

        [HttpGet("range/{id:range(3, 10)}")]
        public string GoodBye(string name, int id)
        {
            return name + " " + id;
        }

        [HttpGet("regex/{id:regex(a(b|c))}")]
        public string Alpha(string name, string id)
        {
            return name + " " + id;
        }


        [HttpPost("query")]
        public List<int> MyLinq(int[] numbers)
        {
            return _studentService.GetData(numbers);
        }

        // action method return types 
        [HttpGet("special")]
        public Student GetStudents()
        {
            return new Student();
        }

        // IActionResult
        [HttpGet("iaction/{id}")]
        public IActionResult GetStudentsData(int id)
        {
            if (id == 0)
            {
                return NotFound("Not Found!!!");
            }
            return Ok(new List<Student>(){
            new Student() {Id=id, Name="Ramya", Email="ramya@example.com" },
            });
        }

        [HttpPost("action/{id}")]
        public ActionResult<Student> GetStudentsDetails(int id , string name)
        {
            if (id == 0)
            {
                return NotFound("Not Found!!");
            }
            if (id == 10 && name == "ramya")
            {
                return new Student() { Id = id, Name = "Ramya", Email = "ramya@example.com" };
            }
            return Ok(new Student() { Id = id, Name = "Ramya", Email = "ramya@example.com" });
        }

        // get method connot have FromBody and FromForm
        [HttpGet("from/{id}")]
        public ActionResult<Student> GetDataFrom([FromQuery] string name, [FromRoute] int id, [FromHeader] string email)
        {
            return Ok(new Student() {Id=id, Name = name, Email=email});
        }

        [HttpPost("body")]
        public ActionResult<Student> GetDataFromBody([FromBody] Student student)
        {
            return Ok(new Student() { Id = student.Id, Name = student.Name, Email = student.Email });
        }

        [HttpPost("form")]
        public ActionResult<Student> GetDataFromForm([FromForm] Student student)
        {
            return Ok(new Student() { Id = student.Id, Name = student.Name, Email = student.Email });
        }
    }
}
