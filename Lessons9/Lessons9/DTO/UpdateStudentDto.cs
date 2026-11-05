using System.ComponentModel.DataAnnotations;

namespace Lessons9.DTO
{
    public class UpdateStudentDto
    {
        [Required(ErrorMessage = "Имя обязательно")]
        [StringLength(50, MinimumLength = 2,
ErrorMessage = "Имя должно содержать от 2 до 50 символов")]
        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        [Required(ErrorMessage = "Группа обязательна")]
        public string Group { get; set; } = string.Empty;
    }
}
