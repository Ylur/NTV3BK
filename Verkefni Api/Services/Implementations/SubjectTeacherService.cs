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
    public class SubjectTeacherService : ISubjectTeacherService
    {
        private readonly ISubjectTeacherRepository _repository;        private readonly ISubjectRepository _subjectRepository;
        private readonly ITeacherRepository _teacherRepository;

        public SubjectTeacherService(ISubjectTeacherRepository repository, ISubjectRepository subjectRepository, ITeacherRepository teacherRepository)
        {
            _repository = repository;
            _subjectRepository = subjectRepository;
            _teacherRepository = teacherRepository;
        }
        public async Task<IEnumerable<SubjectTeacherDto>> GetAllSubjectTeachersAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(MapToDto);
        }

        public async Task<SubjectTeacherDto> GetSubjectTeacherByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return null;

            return MapToDto(entity);
        }

        public async Task<SubjectTeacherDto> CreateSubjectTeacherAsync(SubjectTeacherCreateDto dto)
        {
            // Validate references if needed            var subject = await _subjectRepository.GetByIdAsync(dto.SubjectId);
            if (subject == null)
                throw new KeyNotFoundException($""Subject with ID {dto.SubjectId} not found"");

            var teacher = await _teacherRepository.GetByIdAsync(dto.TeacherId);
            if (teacher == null)
                throw new KeyNotFoundException($""Teacher with ID {dto.TeacherId} not found"");
            var entity = new SubjectTeacher
            {                SubjectId = dto.SubjectId,
                TeacherId = dto.TeacherId            };

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            return MapToDto(entity);
        }

        public async Task UpdateSubjectTeacherAsync(int id, SubjectTeacherUpdateDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($""SubjectTeacher with ID {id} not found"");

            // Update entity properties            // SubjectTeacher updates are not typical as it's a join table
            // Usually you would delete and recreate the relationship
            await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteSubjectTeacherAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($""SubjectTeacher with ID {id} not found"");

            await _repository.DeleteAsync(entity);
            await _repository.SaveChangesAsync();
        }

        // Helper method to map entity to DTO
        private SubjectTeacherDto MapToDto(SubjectTeacher entity)
        {
            return new SubjectTeacherDto
            {
                SubjectTeacherId = entity.SubjectTeacherId,                SubjectId = entity.SubjectId,
                SubjectTitle = entity.Subject?.Title,
                TeacherId = entity.TeacherId,
                TeacherName = entity.Teacher != null ? $""{entity.Teacher.FirstName} {entity.Teacher.LastName}"" : string.Empty            };
        }
    }
}
