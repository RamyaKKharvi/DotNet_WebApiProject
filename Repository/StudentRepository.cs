namespace WebAPITest.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public string MyTest(string name)
        {
            return name;
        }

        public List<int> GetData(int[] numbers)
        {
            var myQuery = (from num in numbers where (num % 2 == 0) select num).ToList();
            var avg = myQuery.Average();
            var contains = myQuery.Contains(4);
            var orderBy = myQuery.OrderBy(x => x).ToList();
            Console.WriteLine("Average: " + avg);
            Console.WriteLine("Contains: " + contains);
            Console.WriteLine(orderBy);
            return myQuery;
        }
    }

    
}
