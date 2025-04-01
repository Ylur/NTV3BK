using System.Collections.Generic;
using System.Threading.Tasks;
using Verkefni_5.Data.DTOs;

namespace Verkefni_5.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherDto>> GetAllTeachersAsync();
        Task<TeacherDto> GetTeacherByIdAsync(int id);
        Task<IEnumerable<TeacherDto>> GetTeachersWithSubjectsAsync();
        Task<TeacherDto> CreateTeacherAsync(TeacherCreateDto teacherDto);
        Task UpdateTeacherAsync(int id, TeacherUpdateDto teacherDto);
        Task DeleteTeacherAsync(int id);
    }
}
