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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly IGroupRepository _groupRepository;

        public StudentService(IStudentRepository repository, IGroupRepository groupRepository)
        {
            _repository = repository;
            _groupRepository = groupRepository;
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(MapToDto);
        }

        public async Task<StudentDto> GetStudentByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return null;

            return MapToDto(entity);
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsByGroupAsync(int groupId)
        {
            var students = await _repository.GetStudentsByGroupAsync(groupId);
            return students.Select(MapToDto);
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsWithMarksAsync()
        {
            var students = await _repository.GetStudentsWithMarksAsync();
            return students.Select(MapToDto);
        }

        public async Task<StudentDto> CreateStudentAsync(StudentCreateDto dto)
        {
            // Validate references
            var group = await _groupRepository.GetByIdAsync(dto.GroupId);
            if (group == null)
                throw new KeyNotFoundException($"Group with ID {dto.GroupId} not found");

            var entity = new Student
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                GroupId = dto.GroupId
            };

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            return MapToDto(entity);
        }

        public async Task UpdateStudentAsync(int id, StudentUpdateDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Student with ID {id} not found");

            // Validate group exists
            var group = await _groupRepository.GetByIdAsync(dto.GroupId);
            if (group == null)
                throw new KeyNotFoundException($"Group with ID {dto.GroupId} not found");

            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;
            entity.GroupId = dto.GroupId;

            await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Student with ID {id} not found");

            await _repository.DeleteAsync(entity);
            await _repository.SaveChangesAsync();
        }

        // Helper method to map entity to DTO
        private StudentDto MapToDto(Student entity)
        {
            return new StudentDto
            {
                StudentId = entity.StudentId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                GroupId = entity.GroupId,
                GroupName = entity.Group?.Name
            };
        }
    }
}
