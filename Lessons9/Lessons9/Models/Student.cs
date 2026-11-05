using System.ComponentModel.DataAnnotations;

namespace Lessons9.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Group { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public StudentProfile? Profile { get; set; }

        public ICollection<Discipline> Disciplines { get; set; } = new List<Discipline>();


    }
}