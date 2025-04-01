using System.ComponentModel.DataAnnotations;

namespace WebAPITest.Model
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is Required!!")]
        public string? Name { get; set; }

        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string? Email { get; set; }

    }
}
