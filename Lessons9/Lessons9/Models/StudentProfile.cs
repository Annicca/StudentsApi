namespace Lessons9.Models
{
    public class StudentProfile
    {
        public int Id { get; set; }
        public string Phone { get; set; } = "";

        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;


    }
}
