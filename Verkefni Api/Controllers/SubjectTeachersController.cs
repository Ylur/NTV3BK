using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using DTOs;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectTeachersController : ControllerBase
    {
        private readonly ISubjectTeacherService _service;
        
        public SubjectTeachersController(ISubjectTeacherService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectTeacherDto>>> GetAll()
        {
            var items = await _service.GetAllSubjectTeachersAsync();
            return Ok(items);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectTeacherDto>> GetById(int id)
        {
            var item = await _service.GetSubjectTeacherByIdAsync(id);
            if (item == null)
                return NotFound();
            
            return Ok(item);
        }
        
        [HttpPost]
        public async Task<ActionResult<SubjectTeacherDto>> Create(SubjectTeacherCreateDto dto)
        {
            var created = await _service.CreateSubjectTeacherAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.SubjectTeacherId }, created);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SubjectTeacherUpdateDto dto)
        {
            await _service.UpdateSubjectTeacherAsync(id, dto);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteSubjectTeacherAsync(id);
            return NoContent();
        }
    }
}
