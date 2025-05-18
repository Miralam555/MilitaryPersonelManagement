using Business.Abstract;
using Entities.DTOs.FamilyMemberForeignTravelDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FamilyMemberForeignTravelsController : ControllerBase
    {
        private readonly IMilitaryPersonelFamilyMemberForeignTravelService _service;

        public FamilyMemberForeignTravelsController(IMilitaryPersonelFamilyMemberForeignTravelService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _service.GetAllTravelsAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("member/{id}/foreigntravels")]
        public async Task<IActionResult> GetAllByMemberIdAsync(int memberId)
        {
            var result = await _service.GetAllByMemberIdAsync(memberId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(FamilyMemberForeignTravelAddDto dto)
        {
            var result = await _service.AddTravelAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(FamilyMemberForeignTraveUpdateDto dto)
        {
            var result = await _service.UpdateTravelAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

    }
}
