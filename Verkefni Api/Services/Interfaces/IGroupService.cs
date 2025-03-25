using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;

namespace Services.Interfaces
{
    public interface IGroupService
    {
        Task<IEnumerable<GroupDto>> GetAllGroupsAsync();
        Task<GroupDto> GetGroupByIdAsync(int id);
        Task<GroupDto> CreateGroupAsync(GroupCreateDto dto);
        Task UpdateGroupAsync(int id, GroupUpdateDto dto);
        Task DeleteGroupAsync(int id);
    }
}
