using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Verkefni_5.Services.Interfaces;
using Verkefni_5.DTOs;

namespace Verkefni_5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _service;
        
        public TeachersController(ITeacherService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherDto>>> GetAll()
        {
            var items = await _service.GetAllTeachersAsync();
            return Ok(items);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherDto>> GetById(int id)
        {
            var item = await _service.GetTeacherByIdAsync(id);
            if (item == null)
                return NotFound();
            
            return Ok(item);
        }
        
        [HttpPost]
        public async Task<ActionResult<TeacherDto>> Create(TeacherCreateDto dto)
        {
            var created = await _service.CreateTeacherAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.TeacherId }, created);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TeacherUpdateDto dto)
        {
            await _service.UpdateTeacherAsync(id, dto);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteTeacherAsync(id);
            return NoContent();
        }
    }
}

