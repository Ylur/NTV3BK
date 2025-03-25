using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;

namespace Services.Interfaces
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync();
        Task<SubjectDto> GetSubjectByIdAsync(int id);
        Task<SubjectDto> CreateSubjectAsync(SubjectCreateDto dto);
        Task UpdateSubjectAsync(int id, SubjectUpdateDto dto);
        Task DeleteSubjectAsync(int id);
    }
}
