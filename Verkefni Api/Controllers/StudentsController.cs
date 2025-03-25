using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using DTOs;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;
        
        public StudentsController(IStudentService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetAll()
        {
            var items = await _service.GetAllStudentsAsync();
            return Ok(items);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetById(int id)
        {
            var item = await _service.GetStudentByIdAsync(id);
            if (item == null)
                return NotFound();
            
            return Ok(item);
        }
        
        [HttpPost]
        public async Task<ActionResult<StudentDto>> Create(StudentCreateDto dto)
        {
            var created = await _service.CreateStudentAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.StudentId }, created);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StudentUpdateDto dto)
        {
            await _service.UpdateStudentAsync(id, dto);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteStudentAsync(id);
            return NoContent();
        }
    }
}
