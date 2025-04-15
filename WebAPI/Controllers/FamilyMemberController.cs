using Business.Abstract;
using Entities.DTOs.FamilyMemberDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FamilyMemberController : Controller
    {
        private readonly IFamilyMemberService _service;

        public FamilyMemberController(IFamilyMemberService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddFamilyMemberAsync(FamilyMemberAddDto dto)
        {
            var result = await _service.AddFamilyMemberAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpGet("getbypersonelid")]
        public async Task<IActionResult> GetByPersonelIdFamilyMemberAsync(int id)
        {
            var result = await _service.GetAllFamilyMembersByPersonelIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllFamilyMemberAsync()
        {
            var result = await _service.GetAllFamilyMembersAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateFamilyMemberAsync(FamilyMemberUpdateAndGetDto dto)
        {
            var result = await _service.UpdateFamilyMemberAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpDelete("delete")]
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
