using WebAPITest.Model;

namespace WebAPITest.Repository;

public interface ITeacherRepository
{
    Task<Teacher> CreateTeacherAsync(Teacher teacher);
    Task<List<Teacher>> GetAllTeachersAsync();
    Task<Teacher> GetTeacherByIdAsync(int id);
    Task<Teacher?> PartialUpdateTeacherDataAsync(Teacher teacher);
    Task<Teacher?> UpdateTeacherDataAsync(Teacher teacher);
    Task<int?> DeleteTeacherAsync(int id);

}
