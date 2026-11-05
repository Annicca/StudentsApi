using Lessons9.DTO;
using Lessons9.Models;

namespace Lessons9.Interfaces
{
    public interface IStudentService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<StudentListDto>> GetAll();

        Task<Student?> GetById(int id);

        Task<List<Student>> GetByGroup(string? group);

        Task<Student?> Create(CreateStudentDto createStudentDto);

        Task<List<StudentResponseDto>> Search(string? group);

        Task<Student?> Update(int id, UpdateStudentDto updatedStudent);

        Task<bool> Delete(int id);

        Task Transaction();
    }
}
