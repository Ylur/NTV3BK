using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Verkefni_5.Services.Interfaces;
using Verkefni_5.DTOs;

namespace Verkefni_5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _service;
        
        public GroupsController(IGroupService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupDto>>> GetAll()
        {
            var items = await _service.GetAllGroupsAsync();
            return Ok(items);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupDto>> GetById(int id)
        {
            var item = await _service.GetGroupByIdAsync(id);
            if (item == null)
                return NotFound();
            
            return Ok(item);
        }
        
        [HttpPost]
        public async Task<ActionResult<GroupDto>> Create(GroupCreateDto dto)
        {
            var created = await _service.CreateGroupAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.GroupId }, created);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, GroupUpdateDto dto)
        {
            await _service.UpdateGroupAsync(id, dto);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteGroupAsync(id);
            return NoContent();
        }
    }
}

