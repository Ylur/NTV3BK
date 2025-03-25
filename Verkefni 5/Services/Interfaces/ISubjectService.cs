using System.Collections.Generic;
using System.Threading.Tasks;
using Verkefni_5.DTOs;

namespace Verkefni_5.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync();
        Task<SubjectDto> GetSubjectByIdAsync(int id);
        Task<IEnumerable<SubjectDto>> GetSubjectsWithTeachersAsync();
        Task<SubjectDto> CreateSubjectAsync(SubjectCreateDto subjectDto);
        Task UpdateSubjectAsync(int id, SubjectUpdateDto subjectDto);
        Task DeleteSubjectAsync(int id);
    }
}
