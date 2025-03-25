using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using DTOs;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _service;
        
        public SubjectsController(ISubjectService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectDto>>> GetAll()
        {
            var items = await _service.GetAllSubjectsAsync();
            return Ok(items);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectDto>> GetById(int id)
        {
            var item = await _service.GetSubjectByIdAsync(id);
            if (item == null)
                return NotFound();
            
            return Ok(item);
        }
        
        [HttpPost]
        public async Task<ActionResult<SubjectDto>> Create(SubjectCreateDto dto)
        {
            var created = await _service.CreateSubjectAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.SubjectId }, created);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SubjectUpdateDto dto)
        {
            await _service.UpdateSubjectAsync(id, dto);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteSubjectAsync(id);
            return NoContent();
        }
    }
}
