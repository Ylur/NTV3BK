using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Verkefni_5.Data.DTOs;
using Verkefni_5.Repositories.Interfaces;
using Verkefni_5.Services.Interfaces;
using Verkefni_5.Data.Models;
using Verkefni_5.Data;

namespace Verkefni_5.Services.Implementations
{
    public class SubjectTeacherService : ISubjectTeacherService
    {
        private readonly ISubjectTeacherRepository _repository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly ITeacherRepository _teacherRepository;

        public SubjectTeacherService(
            ISubjectTeacherRepository repository,
            ISubjectRepository subjectRepository,
            ITeacherRepository teacherRepository)
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

        public async Task<SubjectTeacherDto> GetSubjectTeacherByIdAsync(int subjectId, int teacherId)
        {
            var entity = await _repository.GetByIdAsync(subjectId, teacherId);
            if (entity == null)
                return null;

            return MapToDto(entity);
        }

        public async Task<IEnumerable<SubjectTeacherDto>> GetBySubjectIdAsync(int subjectId)
        {
            var subjectTeachers = await _repository.GetBySubjectIdAsync(subjectId);
            return subjectTeachers.Select(MapToDto);
        }

        public async Task<IEnumerable<SubjectTeacherDto>> GetByTeacherIdAsync(int teacherId)
        {
            var subjectTeachers = await _repository.GetByTeacherIdAsync(teacherId);
            return subjectTeachers.Select(MapToDto);
        }

        public async Task<SubjectTeacherDto> CreateSubjectTeacherAsync(SubjectTeacherCreateDto dto)
        {
            // Validate subject exists
            var subject = await _subjectRepository.GetByIdAsync(dto.SubjectId);
            if (subject == null)
                throw new KeyNotFoundException($"Subject with ID {dto.SubjectId} not found");

            // Validate teacher exists
            var teacher = await _teacherRepository.GetByIdAsync(dto.TeacherId);
            if (teacher == null)
                throw new KeyNotFoundException($"Teacher with ID {dto.TeacherId} not found");

            var entity = new SubjectTeacher
            {
                SubjectId = dto.SubjectId,
                TeacherId = dto.TeacherId
            };

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            return MapToDto(entity);
        }

        public async Task DeleteSubjectTeacherAsync(int subjectId, int teacherId)
        {
            var entity = await _repository.GetByIdAsync(subjectId, teacherId);
            if (entity == null)
                throw new KeyNotFoundException($"SubjectTeacher with SubjectID {subjectId} and TeacherID {teacherId} not found");

            await _repository.DeleteAsync(entity);
            await _repository.SaveChangesAsync();
        }

        // Helper method to map entity to DTO
        private SubjectTeacherDto MapToDto(SubjectTeacher entity)
        {
            return new SubjectTeacherDto
            {
                SubjectId = entity.SubjectId,
                SubjectTitle = entity.Subject?.Title,
                TeacherId = entity.TeacherId,
                TeacherName = entity.Teacher != null ? $"{entity.Teacher.FirstName} {entity.Teacher.LastName}" : string.Empty
            };
        }
    }
}
