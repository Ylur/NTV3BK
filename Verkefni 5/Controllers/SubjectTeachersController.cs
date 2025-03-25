using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Verkefni_5.Services.Interfaces;
using Verkefni_5.DTOs;

namespace Verkefni_5.Controllers
{
    [ApiController]
    [Route("api/subject-teachers")]
    public class SubjectTeachersController : ControllerBase
    {
        private readonly ISubjectTeacherService _subjectTeacherService;

        public SubjectTeachersController(ISubjectTeacherService subjectTeacherService)
        {
            _subjectTeacherService = subjectTeacherService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectTeacherDto>>> GetAll()
        {
            var subjectTeachers = await _subjectTeacherService.GetAllSubjectTeachersAsync();
            return Ok(subjectTeachers);
        }

        [HttpGet("{subjectId}/{teacherId}")]
        public async Task<ActionResult<SubjectTeacherDto>> GetById(int subjectId, int teacherId)
        {
            var subjectTeacher = await _subjectTeacherService.GetSubjectTeacherByIdAsync(subjectId, teacherId);
            if (subjectTeacher == null)
                return NotFound();

            return Ok(subjectTeacher);
        }

        [HttpGet("by-subject/{subjectId}")]
        public async Task<ActionResult<IEnumerable<SubjectTeacherDto>>> GetBySubject(int subjectId)
        {
            var subjectTeachers = await _subjectTeacherService.GetBySubjectIdAsync(subjectId);
            return Ok(subjectTeachers);
        }

        [HttpGet("by-teacher/{teacherId}")]
        public async Task<ActionResult<IEnumerable<SubjectTeacherDto>>> GetByTeacher(int teacherId)
        {
            var subjectTeachers = await _subjectTeacherService.GetByTeacherIdAsync(teacherId);
            return Ok(subjectTeachers);
        }

        [HttpPost]
        public async Task<ActionResult<SubjectTeacherDto>> Create(SubjectTeacherCreateDto subjectTeacherDto)
        {
            try
            {
                var createdSubjectTeacher = await _subjectTeacherService.CreateSubjectTeacherAsync(subjectTeacherDto);
                return CreatedAtAction(
                    nameof(GetById),
                    new { subjectId = createdSubjectTeacher.SubjectId, teacherId = createdSubjectTeacher.TeacherId },
                    createdSubjectTeacher);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{subjectId}/{teacherId}")]
        public async Task<IActionResult> Delete(int subjectId, int teacherId)
        {
            try
            {
                await _subjectTeacherService.DeleteSubjectTeacherAsync(subjectId, teacherId);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
