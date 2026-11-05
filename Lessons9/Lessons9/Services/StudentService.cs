using Lessons9.Data;
using Lessons9.DTO;
using Lessons9.Exceptions;
using Lessons9.Interfaces;
using Lessons9.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Caching.Memory;

namespace Lessons9.Services
{
    public class StudentService:IStudentService
    {

        private readonly AppDbContext context;
        private readonly IMemoryCache _cache;
        private const string ListCacheKey = "students:list";



        public StudentService(
            AppDbContext dbContext,
            IMemoryCache cache)
        {
            this.context = dbContext;
            this._cache = cache;
        }

        public async Task<List<StudentListDto>> GetAll()
        {
            if (_cache.TryGetValue(
                ListCacheKey,
                out List<StudentListDto>? cached) && cached is not null)
            {
                return cached;
            }


            var students = await context.Students
                .Select(s => new StudentListDto
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToListAsync();

            _cache.Set(ListCacheKey, students, TimeSpan.FromSeconds(30));
            
            return students;

        }

        public async Task<Student?> GetById(int id)
        {
            return await context.Students.FindAsync(id);
        }

        public async Task<Student?> Create(CreateStudentDto createStudentDto)
        {
            var student = new Student
            {
                Name = createStudentDto.Name,
                Age = createStudentDto.Age,
                Group = createStudentDto.Group
            };
            context.Students.Add(student);

            await context.SaveChangesAsync();

            _cache.Remove(ListCacheKey);

            return student;
        }

        public async Task<Student?> Update(int id, UpdateStudentDto updatedStudent)
        {
            var student = await context.Students.FindAsync(id); 
            
            if (student == null) {
                return null;
            };
            
            student.Name = updatedStudent.Name;
            student.Group = updatedStudent.Group;
            student.Age = updatedStudent.Age;

            await context.SaveChangesAsync();
            return student;
        }

        public static bool CanDeleteStudent(Student student)
        {
            return !student.Disciplines.Any();
        }


        public async Task<bool> Delete(int id)
        {
            var student = await context.Students
             .Include(s => s.Disciplines)
             .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null) {
                return false;
            };

            if (!CanDeleteStudent(student))
            {
                throw new StudentHasDisciplinesException(id);
            }


            context.Students.Remove(student); 
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<StudentResponseDto>> Search(string? group)
        {

            var query = context.Students
            .Include(s => s.Disciplines)
            .Select(student => new StudentResponseDto
            {
                Name = student.Name,
                Group = student.Group,
                Age = student.Age,
                Disciplines = student.Disciplines
                    .Select(discipline => new DisciplineResponseDto
                    {
                        Id = discipline.Id,
                        Name = discipline.Name
                    })
                    .ToList()
            });

            return await query.ToListAsync();

        }


        public async Task<List<Student>> GetByGroup(string? group)
        {
            IQueryable<Student> query = context.Students;
            if (!string.IsNullOrWhiteSpace(group))
            {
                query = query.Where(
                student => student.Group == group);
            }
            query = query
            .OrderBy(student => student.Name)
            .ThenBy(student => student.Id);
            return await query.ToListAsync();
        }

        public async Task Transaction()
        {
            await using var transaction = await context.Database.BeginTransactionAsync(); 
            try {
                var discipline = new Discipline { Name = "Базы данных" }; 
                context.Disciplines.Add(discipline);
                await context.SaveChangesAsync(); 
                var lesson = new Lesson
                {
                    Topic = "Введение в базы данных",
                    DisciplineId = discipline.Id
                };
                context.Lessons.Add(lesson);
                await context.SaveChangesAsync(); // ошибка


                if (true)
                {
                    throw new Exception("Ошибка при создании занятия");
                }
                //await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync(); 
                throw new Exception("Транзакция не удалась");
            }

        }

    }
}
