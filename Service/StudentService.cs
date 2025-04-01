using WebAPITest.Repository;

namespace WebAPITest.Service
{
    public class StudentService : IStudentService
    {
        public readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public string MyName(string name)
        {
            return name.ToUpper() + " " + name.ToLower();
        }

        public List<int> GetData(int[] numbers)
        {
            return _studentRepository.GetData(numbers);
        }


    }
}
