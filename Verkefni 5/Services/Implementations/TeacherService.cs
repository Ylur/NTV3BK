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

        public async Task<IEnumerable<TeacherDto>> GetTeachersWithSubjectsAsync()
        {
            var teachers = await _repository.GetTeachersWithSubjectsAsync();
            return teachers.Select(MapToDto);
        }

        public async Task<TeacherDto> CreateTeacherAsync(TeacherCreateDto dto)
        {
            var entity = new Teacher
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            return MapToDto(entity);
        }

        public async Task UpdateTeacherAsync(int id, TeacherUpdateDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Teacher with ID {id} not found");

            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;

            await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteTeacherAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Teacher with ID {id} not found");

            await _repository.DeleteAsync(entity);
            await _repository.SaveChangesAsync();
        }

        // Helper method to map entity to DTO
        private TeacherDto MapToDto(Teacher entity)
        {
            return new TeacherDto
            {
                TeacherId = entity.TeacherId,
                FirstName = entity.FirstName,
                LastName = entity.LastName
            };
        }
    }
}
