namespace WebAPITest.Service
{
    public interface IStudentService
    {
        string MyName(string name);

        List<int> GetData(int[] numbers);
    }
}
