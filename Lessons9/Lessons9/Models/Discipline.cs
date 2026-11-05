namespace Lessons9.Models
{
    public class Discipline
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

        public ICollection<Student> Students { get; set; } = new List<Student>();

    }
}
