using Microsoft.EntityFrameworkCore;

namespace WebAPITest.Model
{
    public class TeacherDBContext : DbContext
    {
        public TeacherDBContext(DbContextOptions<TeacherDBContext> options) : base(options)
        {
            
        }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
