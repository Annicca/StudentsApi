namespace Lessons9.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Topic { get; set; } = "";

        public int DisciplineId { get; set; }
        public Discipline Discipline { get; set; } = null!;


    }
}
