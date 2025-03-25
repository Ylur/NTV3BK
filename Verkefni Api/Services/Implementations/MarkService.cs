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
    public class MarkService : IMarkService
    {
        private readonly IMarkRepository _repository;        private readonly IStudentRepository _studentRepository;
        private readonly ISubjectRepository _subjectRepository;

        public MarkService(IMarkRepository repository, IStudentRepository studentRepository, ISubjectRepository subjectRepository)
        {
            _repository = repository;
            _studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
        }
        public async Task<IEnumerable<MarkDto>> GetAllMarksAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(MapToDto);
        }

        public async Task<MarkDto> GetMarkByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return null;

            return MapToDto(entity);
        }

        public async Task<MarkDto> CreateMarkAsync(MarkCreateDto dto)
        {
            // Validate references if needed            var student = await _studentRepository.GetByIdAsync(dto.StudentId);
            if (student == null)
                throw new KeyNotFoundException($""Student with ID {dto.StudentId} not found"");

            var subject = await _subjectRepository.GetByIdAsync(dto.SubjectId);
            if (subject == null)
                throw new KeyNotFoundException($""Subject with ID {dto.SubjectId} not found"");
            var entity = new Mark
            {                StudentId = dto.StudentId,
                SubjectId = dto.SubjectId,
                Date = dto.Date,
                Value = dto.Value            };

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            return MapToDto(entity);
        }

        public async Task UpdateMarkAsync(int id, MarkUpdateDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($""Mark with ID {id} not found"");

            // Update entity properties            entity.Date = dto.Date;
            entity.Value = dto.Value;
            await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteMarkAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($""Mark with ID {id} not found"");

            await _repository.DeleteAsync(entity);
            await _repository.SaveChangesAsync();
        }

        // Helper method to map entity to DTO
        private MarkDto MapToDto(Mark entity)
        {
            return new MarkDto
            {
                MarkId = entity.MarkId,                StudentId = entity.StudentId,
                StudentName = entity.Student != null ? $""{entity.Student.FirstName} {entity.Student.LastName}"" : string.Empty,
                SubjectId = entity.SubjectId,
                SubjectTitle = entity.Subject?.Title,
                Date = entity.Date,
                Value = entity.Value            };
        }
    }
}
