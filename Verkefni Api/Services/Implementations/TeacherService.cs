using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOs;
using Repositories.Interfaces;
using Services.Interfaces;
using SchoolDB;

namespace Services.Implementations
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _repository;
        public TeacherService(ITeacherRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<TeacherDto>> GetAllTeachersAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(MapToDto);
        }

        public async Task<TeacherDto> GetTeacherByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return null;

            return MapToDto(entity);
        }

        public async Task<TeacherDto> CreateTeacherAsync(TeacherCreateDto dto)
        {
            // Validate references if needed
            var entity = new Teacher
            {                FirstName = dto.FirstName,
                LastName = dto.LastName            };

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            return MapToDto(entity);
        }

        public async Task UpdateTeacherAsync(int id, TeacherUpdateDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($""Teacher with ID {id} not found"");

            // Update entity properties            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;
            await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteTeacherAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($""Teacher with ID {id} not found"");

            await _repository.DeleteAsync(entity);
            await _repository.SaveChangesAsync();
        }

        // Helper method to map entity to DTO
        private TeacherDto MapToDto(Teacher entity)
        {
            return new TeacherDto
            {
                TeacherId = entity.TeacherId,                FirstName = entity.FirstName,
                LastName = entity.LastName            };
        }
    }
}
