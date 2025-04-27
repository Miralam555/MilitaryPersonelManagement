using Business.Abstract;
using Entities.DTOs.MilitaryServiceHistoryDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MilitaryServiceHistoryController : ControllerBase
    {
        private readonly IMilitaryServiceHistoryService _service;

        public MilitaryServiceHistoryController(IMilitaryServiceHistoryService service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllServiceHistoriesAsync()
        {
            var result = await _service.GetAllServiceHistoriesAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getallbypersonelid")]
        public async Task<IActionResult> GetAllServiceHistoriesByPersonelIdAsync(int personelId)
        {
            var result = await _service.GetAllServiceHistoriesByPersonelIdAsync(personelId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getallbyinjunctionid")]
        public async Task<IActionResult> GetAllServiceHistoriesByInjunctionIdAsync(int injunctionId)
        {
            var result = await _service.GetAllServiceHistoriesByInjunctionIdAsync(injunctionId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
         [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _service.GetServiceHistoryByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddServiceHistoryAsync(MilitaryServiceHistoryAddDto dto)
        {
            var result = await _service.AddHistoryAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateServiceHistoryAsync(MilitaryServiceHistoryUpdateDto dto)
        {
            var result = await _service.UpdateHistoryAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteServiceHistoryAsync(int id)
        {
            var result = await _service.DeleteHistoryAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }

    }
}
