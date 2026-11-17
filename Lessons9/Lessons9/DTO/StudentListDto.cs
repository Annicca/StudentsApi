using System.ComponentModel.DataAnnotations;

namespace Lessons9.DTO
{
    public class StudentListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }
        public string Group { get; set; } = string.Empty;

    }
}
