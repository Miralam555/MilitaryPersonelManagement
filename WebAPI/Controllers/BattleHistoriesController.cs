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
    public class BattleHistoriesController : ControllerBase
    {
        IBattleHistoryService _service;
        public BattleHistoriesController(IBattleHistoryService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHistoryAsync()
        {
            var result = await _service.GetAllBattleHistoryAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHistoryByIdAsync(int id)
        {
            var result = await _service.GetHistoryByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("personel/{personelId}/histories")]
        public async Task<IActionResult> GetAllByPersonelIdAsync(int personelId)
        {
            var result = await _service.GetAllHistoriesByPersonelIdAsync(personelId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


        [HttpPost]
        public async Task<IActionResult> AddHistoryAsync(BattleHistoryAddDto dto)
        {
            
            var result=await _service.AddBattleHistoryAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateAsyncAsync(BattleHistoryUpdateDto dto)
        {
            var result = await _service.UpdateHistoryAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _service.DeleteHistoryAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
