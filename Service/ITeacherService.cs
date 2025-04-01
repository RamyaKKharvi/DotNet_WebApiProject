using WebAPITest.Model;

namespace WebAPITest.Service
{
    public interface ITeacherService
    {
        Task<Teacher> CreateTeacherAsync(Teacher teacher);
        Task<int?> DeleteTeacherAsync(int id);
        Task<List<Teacher>> GetAllTeachersAsync();
        Task<Teacher> GetTeachersByIdAsync(int id);
        Task<Teacher?> PartialUpdateTeacherDataAsync(Teacher teacher);
        Task<Teacher?> UpdateTeacherDataAsync(Teacher teacher);
    }
}
