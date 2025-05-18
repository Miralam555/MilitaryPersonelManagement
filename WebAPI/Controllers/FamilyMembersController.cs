using Business.Abstract;
using Entities.DTOs.FamilyMemberDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FamilyMembersController : ControllerBase
    {
        private readonly IFamilyMemberService _service;

        public FamilyMembersController(IFamilyMemberService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddFamilyMemberAsync(FamilyMemberAddDto dto)
        {
            var result = await _service.AddFamilyMemberAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpGet("personel/{personelId}/familymembers")]
        public async Task<IActionResult> GetAllFamilyMembersByPersonelIdAsync(int personelId)
        {
            var result = await _service.GetAllFamilyMembersByPersonelIdAsync(personelId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
         [HttpGet("{id}")]
        public async Task<IActionResult> GetMemberByIdAsync(int id)
        {
            var result = await _service.GetMemberByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFamilyMemberAsync()
        {
            var result = await _service.GetAllFamilyMembersAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFamilyMemberAsync(FamilyMemberUpdateDto dto)
        {
            var result = await _service.UpdateFamilyMemberAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFamilyMemberAsync(int id)
        {
            var result = await _service.DeleteFamilyMemberAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }


    }
}
