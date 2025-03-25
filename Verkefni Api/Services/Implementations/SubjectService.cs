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
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _repository;
        public SubjectService(ISubjectRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(MapToDto);
        }

        public async Task<SubjectDto> GetSubjectByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return null;

            return MapToDto(entity);
        }

        public async Task<SubjectDto> CreateSubjectAsync(SubjectCreateDto dto)
        {
            // Validate references if needed
            var entity = new Subject
            {                Title = dto.Title            };

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            return MapToDto(entity);
        }

        public async Task UpdateSubjectAsync(int id, SubjectUpdateDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($""Subject with ID {id} not found"");

            // Update entity properties            entity.Title = dto.Title;
            await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteSubjectAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($""Subject with ID {id} not found"");

            await _repository.DeleteAsync(entity);
            await _repository.SaveChangesAsync();
        }

        // Helper method to map entity to DTO
        private SubjectDto MapToDto(Subject entity)
        {
            return new SubjectDto
            {
                SubjectId = entity.SubjectId,                Title = entity.Title            };
        }
    }
}
