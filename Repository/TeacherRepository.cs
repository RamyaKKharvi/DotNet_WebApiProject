using Microsoft.EntityFrameworkCore;
using WebAPITest.Model;

namespace WebAPITest.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly TeacherDBContext _dbContext;

        public TeacherRepository(TeacherDBContext dbContext)
        {
            _dbContext = dbContext;   
        }

        public async Task<Teacher> CreateTeacherAsync(Teacher teacher)
        {
            var records = new Teacher()
            {
                Name = teacher.Name,
                Email = teacher.Email,
                Subject = teacher.Subject,
            };
            _dbContext.Teachers.Add(records);
            await _dbContext.SaveChangesAsync();
            var addedTeacher = await GetTeacherByIdAsync(records.Id);
            return addedTeacher;
        }

        public async Task<List<Teacher>> GetAllTeachersAsync()
        {
            var teachers = await _dbContext.Teachers.Select(x=> new Teacher()
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Subject = x.Subject,
            }).ToListAsync();

            return teachers;
        }

        public async Task<Teacher> GetTeacherByIdAsync(int id)
        {
            var teacher = await _dbContext.Teachers.Where(x => x.Id == id).FirstOrDefaultAsync();
            return teacher;
        }

        public async Task<Teacher?> UpdateTeacherDataAsync(Teacher teacher)
        {
            var teacherData = new Teacher()
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Email = teacher.Email,
                Subject = teacher.Subject
            };
            _dbContext.Teachers.Update(teacherData);
            await _dbContext.SaveChangesAsync();
            return teacherData;
        }

        public async Task<Teacher?> PartialUpdateTeacherDataAsync(Teacher teacher)
        {
            var teacherData = _dbContext.Teachers.Where(x=>x.Id == teacher.Id).FirstOrDefault();
            if (teacherData == null)
            {
                return null;
            }
            if (teacher.Name != null && teacher.Name != teacherData.Name)
            {
                teacherData.Name = teacher.Name;
            }

            if (teacher.Email != null && teacher.Email != teacherData.Email)
            {
                teacherData.Email = teacher.Email;
            }

            if (teacher.Subject != null && teacher.Subject != teacherData.Subject)
            {
                teacherData.Subject = teacher.Subject;
            }
            
            await _dbContext.SaveChangesAsync();
            return teacherData;
        }

        public async Task<int?> DeleteTeacherAsync(int id)
        {
            var teacher = new Teacher()
            {
                Id = id
            };
        
            _dbContext.Teachers.Remove(teacher);
            await _dbContext.SaveChangesAsync();
            return teacher.Id;
        }
    }
}
