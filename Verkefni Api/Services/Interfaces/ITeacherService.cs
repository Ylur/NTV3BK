using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;

namespace Services.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherDto>> GetAllTeachersAsync();
        Task<TeacherDto> GetTeacherByIdAsync(int id);
        Task<TeacherDto> CreateTeacherAsync(TeacherCreateDto dto);
        Task UpdateTeacherAsync(int id, TeacherUpdateDto dto);
        Task DeleteTeacherAsync(int id);
    }
}
