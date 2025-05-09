using Business.Abstract;
using Entities.DTOs.FamilyMemberDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FamilyMemberController : ControllerBase
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
        [HttpGet("getallbypersonelid")]
        public async Task<IActionResult> GetAllFamilyMembersByPersonelIdAsync(int personelId)
        {
            var result = await _service.GetAllFamilyMembersByPersonelIdAsync(personelId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
         [HttpGet("getbyid")]
        public async Task<IActionResult> GetMemberByIdAsync(int id)
        {
            var result = await _service.GetMemberByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllFamilyMemberAsync()
        {
            var result = await _service.GetAllFamilyMembersAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateFamilyMemberAsync(FamilyMemberUpdateDto dto)
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
