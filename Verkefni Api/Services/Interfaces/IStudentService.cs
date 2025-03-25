using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;

namespace Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
        Task<StudentDto> GetStudentByIdAsync(int id);
        Task<StudentDto> CreateStudentAsync(StudentCreateDto dto);
        Task UpdateStudentAsync(int id, StudentUpdateDto dto);
        Task DeleteStudentAsync(int id);
    }
}
