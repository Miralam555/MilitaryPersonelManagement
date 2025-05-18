using Business.Abstract;
using Entities.DTOs.MilitaryPersonelPenaltyDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MilitaryPersonelPenaltiesController : ControllerBase
    {
        public IMilitaryPersonelPenaltyService _service;

        public MilitaryPersonelPenaltiesController(IMilitaryPersonelPenaltyService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPenaltiesAsync()
        {
            var result = await _service.GetAllPenaltiesAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("personel/{personelId}/penalties")]
        public async Task<IActionResult> GetAllPenaltiesByPersonelIdAsync(int personelId)
        {
            var result=await _service.GetAllPenaltiesByPersonelIdAsync(personelId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPenaltyByIdAsync(int id)
        {
            var result = await _service.GetPenaltyByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> AddPenaltyAsync(PenaltyAddDto dto)
        {
            var result=await _service.AddPenaltyAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
                
            return BadRequest(result.Message);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePenaltyAsync(PenaltyUpdateDto dto)
        {
            var result = await _service.UpdatePenaltyAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePenaltyAsync(int id)
        {
            var result = await _service.DeletePenaltyAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
        
    }
}
