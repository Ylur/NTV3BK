using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;

namespace Services.Interfaces
{
    public interface ISubjectTeacherService
    {
        Task<IEnumerable<SubjectTeacherDto>> GetAllSubjectTeachersAsync();
        Task<SubjectTeacherDto> GetSubjectTeacherByIdAsync(int id);
        Task<SubjectTeacherDto> CreateSubjectTeacherAsync(SubjectTeacherCreateDto dto);
        Task UpdateSubjectTeacherAsync(int id, SubjectTeacherUpdateDto dto);
        Task DeleteSubjectTeacherAsync(int id);
    }
}
