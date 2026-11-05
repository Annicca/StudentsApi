using Lessons9.Models;

namespace Lessons9.DTO
{
    public class StudentResponseDto
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Group { get; set; } = string.Empty;

        public List<DisciplineResponseDto> Disciplines { get; set; } = new List<DisciplineResponseDto>();
    }
}
