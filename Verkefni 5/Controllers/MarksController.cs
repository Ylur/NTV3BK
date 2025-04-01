using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Verkefni_5.Services.Interfaces;
using Verkefni_5.Data.DTOs;

namespace Verkefni_5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarksController : ControllerBase
    {
        private readonly IMarkService _service;
        
        public MarksController(IMarkService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarkDto>>> GetAll()
        {
            var items = await _service.GetAllMarksAsync();
            return Ok(items);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<MarkDto>> GetById(int id)
        {
            var item = await _service.GetMarkByIdAsync(id);
            if (item == null)
                return NotFound();
            
            return Ok(item);
        }
        
        [HttpPost]
        public async Task<ActionResult<MarkDto>> Create(MarkCreateDto dto)
        {
            var created = await _service.CreateMarkAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.MarkId }, created);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MarkUpdateDto dto)
        {
            await _service.UpdateMarkAsync(id, dto);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteMarkAsync(id);
            return NoContent();
        }
    }
}

