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
    public class PersonelReputationRiskFindingsController : ControllerBase
    {
        private readonly IMilitaryPersonelReputationRiskFindingService _service;

        public PersonelReputationRiskFindingsController(IMilitaryPersonelReputationRiskFindingService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRisksAsync()
        {
            var result = await _service.GetAllRisksAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("personel/{personelId}/risks")]
        public async Task<IActionResult> GetAllRisksByPersonelIdAsync(int personelId)
        {
            var result = await _service.GetAllRisksByPersonelIdAsync(personelId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            
            return BadRequest(result.Message);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRiskByIdAsync(int id)
        {
            var result = await _service.GetRiskByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> AddRiskAsync(PersonelReputationRiskFindingAddDto dto)
        {
            var result = await _service.AddRiskAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRiskAsync(PersonelReputationRiskFindingUpdateDto dto)
        {
            var result = await _service.UpdateRiskAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("{id}")]
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
