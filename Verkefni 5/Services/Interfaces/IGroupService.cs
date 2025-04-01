using System.Collections.Generic;
using System.Threading.Tasks;
using Verkefni_5.Data.DTOs;

namespace Verkefni_5.Services.Interfaces
{
    public interface IGroupService
    {
        Task<IEnumerable<GroupDto>> GetAllGroupsAsync();
        Task<GroupDto> GetGroupByIdAsync(int id);
        Task<IEnumerable<GroupDto>> GetGroupsWithStudentsAsync();
        Task<GroupDto> CreateGroupAsync(GroupCreateDto groupDto);
        Task UpdateGroupAsync(int id, GroupUpdateDto groupDto);
        Task DeleteGroupAsync(int id);
    }
}
