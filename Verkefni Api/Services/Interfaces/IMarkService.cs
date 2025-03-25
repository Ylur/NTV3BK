using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;

namespace Services.Interfaces
{
    public interface IMarkService
    {
        Task<IEnumerable<MarkDto>> GetAllMarksAsync();
        Task<MarkDto> GetMarkByIdAsync(int id);
        Task<MarkDto> CreateMarkAsync(MarkCreateDto dto);
        Task UpdateMarkAsync(int id, MarkUpdateDto dto);
        Task DeleteMarkAsync(int id);
    }
}
