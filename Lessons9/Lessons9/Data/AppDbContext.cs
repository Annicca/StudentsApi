using Lessons9.Models;
using Microsoft.EntityFrameworkCore;

namespace Lessons9.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(
            DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Student> Students
            => Set<Student>();

        public DbSet<Lesson> Lessons => Set<Lesson>();

        public DbSet<Discipline> Disciplines => Set<Discipline>();

        public DbSet<StudentProfile> StudentProfiles => Set<StudentProfile>();

    }

}
