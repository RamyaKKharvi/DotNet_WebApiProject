using Microsoft.AspNetCore.Mvc;
using WebAPITest.Model;
using WebAPITest.Repository;

namespace WebAPITest.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _repository;
        public TeacherService(ITeacherRepository repository)
        {
            _repository = repository;
        }
        public async Task<Teacher> CreateTeacherAsync(Teacher teacher)
        {
            return await _repository.CreateTeacherAsync(teacher);
        }

        public async Task<List<Teacher>> GetAllTeachersAsync()
        {
            return await _repository.GetAllTeachersAsync();
        }

        public async Task<Teacher> GetTeachersByIdAsync(int id)
        {
            return await _repository.GetTeacherByIdAsync(id);
        }

        public async Task<Teacher?> UpdateTeacherDataAsync(Teacher teacher)
        {
            return await _repository.UpdateTeacherDataAsync(teacher);
        }
        public async Task<Teacher?> PartialUpdateTeacherDataAsync(Teacher teacher)
        {
            return await _repository.PartialUpdateTeacherDataAsync(teacher);
        }

        public async Task<int?> DeleteTeacherAsync(int id)
        {
            return await _repository.DeleteTeacherAsync(id);
        }
    }
}
