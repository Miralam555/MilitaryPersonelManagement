using Business.Abstract;
using Entities.DTOs.MilitaryPersonelRecognitionDtos;
using Entities.DTOs.PersonelReputationRiskFindingDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonelReputationRiskFindingController : ControllerBase
    {
        private readonly IMilitaryPersonelReputationRiskFindingService _service;

        public PersonelReputationRiskFindingController(IMilitaryPersonelReputationRiskFindingService service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllRisksAsync()
        {
            var result = await _service.GetAllRisksAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getallbypersonelid")]
        public async Task<IActionResult> GetAllRisksByPersonelIdAsync(int personelId)
        {
            var result = await _service.GetAllRisksByPersonelIdAsync(personelId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetRiskByIdAsync(int id)
        {
            var result = await _service.GetRiskByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddRiskAsync(PersonelReputationRiskFindingAddDto dto)
        {
            var result = await _service.AddRiskAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateRiskAsync(PersonelReputationRiskFindingUpdateDto dto)
        {
            var result = await _service.UpdateRiskAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteRiskAsync(int id)
        {
            var result = await _service.DeleteRiskAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
