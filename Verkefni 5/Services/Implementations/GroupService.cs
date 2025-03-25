using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolDatabase;
using Verkefni_5.DTOs;
using Verkefni_5.Repositories.Interfaces;
using Verkefni_5.Services.Interfaces;

namespace Verkefni_5.Services.Implementations
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _repository;

        public GroupService(IGroupRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GroupDto>> GetAllGroupsAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(MapToDto);
        }

        public async Task<GroupDto> GetGroupByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return null;

            return MapToDto(entity);
        }

        public async Task<IEnumerable<GroupDto>> GetGroupsWithStudentsAsync()
        {
            var groups = await _repository.GetGroupsWithStudentsAsync();
            return groups.Select(MapToDto);
        }

        public async Task<GroupDto> CreateGroupAsync(GroupCreateDto dto)
        {
            var entity = new Group
            {
                Name = dto.Name
            };

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            return MapToDto(entity);
        }

        public async Task UpdateGroupAsync(int id, GroupUpdateDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Group with ID {id} not found");

            entity.Name = dto.Name;

            await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteGroupAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Group with ID {id} not found");

            await _repository.DeleteAsync(entity);
            await _repository.SaveChangesAsync();
        }

        // Helper method to map entity to DTO
        private GroupDto MapToDto(Group entity)
        {
            return new GroupDto
            {
                GroupId = entity.GroupId,
                Name = entity.Name,
                StudentCount = entity.Students?.Count ?? 0
            };
        }
    }
}
