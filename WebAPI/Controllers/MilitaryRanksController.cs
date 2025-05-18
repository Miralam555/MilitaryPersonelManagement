using Business.Abstract;
using Entities.DTOs.MilitaryRankDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MilitaryRanksController : ControllerBase
    {
        private readonly IMilitaryRankService _service;

        public MilitaryRanksController(IMilitaryRankService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRanksAsync()
        {
            var result = await _service.GetAllRanksAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("personel/{personelId}/ranks")]
        public async Task<IActionResult> GetAllRanksByPersonelIdAsync(int personelId)
        {
            var result = await _service.GetAllRanksByPersonelIdAsync(personelId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("injunction/{injunctionId}/ranks")]
        public async Task<IActionResult> GetAllRanksByInjunctionIdAsync(int injunctionId)
        {
            var result = await _service.GetAllRanksByInjunctionIdAsync(injunctionId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRankByIdAsync(int id)
        {
            var result = await _service.GetRankByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> AddRankAsync(MilitaryRankAddDto dto)
        {
            var result = await _service.AddRankAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRankAsync(MilitaryRankUpdateDto dto)
        {
            var result = await _service.UpdateRankAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRankAsync(int id)
        {
            var result = await _service.DeleteRankAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
    }
}
