using System.Collections.Generic;
using System.Threading.Tasks;
using Verkefni_5.DTOs;

namespace Verkefni_5.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
        Task<StudentDto> GetStudentByIdAsync(int id);
        Task<IEnumerable<StudentDto>> GetStudentsByGroupAsync(int groupId);
        Task<IEnumerable<StudentDto>> GetStudentsWithMarksAsync();
        Task<StudentDto> CreateStudentAsync(StudentCreateDto studentDto);
        Task UpdateStudentAsync(int id, StudentUpdateDto studentDto);
        Task DeleteStudentAsync(int id);
    }
}
