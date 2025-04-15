using Business.Abstract;
using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Entities.DTOs.BattleHistoryDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BattleHistoryController : ControllerBase
    {
        IBattleHistoryService _service;
        public BattleHistoryController(IBattleHistoryService service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllHistory()
        {
            var result = await _service.GetAllBattleHistoryAsync();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallbypersonelId")]
        public async Task<IActionResult> GetAllById(int id)
        {
            var result = await _service.GetAllHistoryByPersonelIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("addbattlehistory")]
        public async Task<IActionResult> AddHistory(BattleHistoryAddDto dto)
        {
            
            var result=await _service.AddBattleHistoryAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result=await _service.GetByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync(BattleHistoryUpdateAndGetDto dto)
        {
            var result = await _service.UpdateHistoryAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _service.DeleteHistoryAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
