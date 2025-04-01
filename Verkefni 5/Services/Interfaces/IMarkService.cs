using System.Collections.Generic;
using System.Threading.Tasks;
using Verkefni_5.Data.DTOs;

namespace Verkefni_5.Services.Interfaces
{
    public interface IMarkService
    {
        Task<IEnumerable<MarkDto>> GetAllMarksAsync();
        Task<MarkDto> GetMarkByIdAsync(int id);
        Task<IEnumerable<MarkDto>> GetMarksByStudentAsync(int studentId);
        Task<IEnumerable<MarkDto>> GetMarksBySubjectAsync(int subjectId);
        Task<MarkDto> CreateMarkAsync(MarkCreateDto markDto);
        Task UpdateMarkAsync(int id, MarkUpdateDto markDto);
        Task DeleteMarkAsync(int id);
    }
}
