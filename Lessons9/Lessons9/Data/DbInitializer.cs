using Lessons9.Models;
using Microsoft.EntityFrameworkCore;

namespace Lessons9.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(
            AppDbContext context)
        {
            await context.Database.MigrateAsync();

            if (await context.Students.AnyAsync())
            {
                return;
            }

            context.Students.AddRange(
                new Student
                {
                    Name = "Анна Смирнова",
                    Age = 18,
                    Group = "ИС-21",
                    Email = "anna@example.com"
                },
                new Student
                {
                    Name = "Иван Петров",
                    Age = 19,
                    Group = "ИС-21",
                    Email = "ivan@example.com"
                },
                new Student
                {
                    Name = "Мария Иванова",
                    Age = 18,
                    Group = "ИС-22",
                    Email = "maria@example.com"
                }
            );

            await context.SaveChangesAsync();
        }
    }
}