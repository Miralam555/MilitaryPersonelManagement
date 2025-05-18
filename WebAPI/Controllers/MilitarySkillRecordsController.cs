using Business.Abstract;
using Entities.DTOs.MilitarySkillRecordDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MilitarySkillRecordsController : ControllerBase
    {
        private readonly IMilitarySkillRecordService _service;

        public MilitarySkillRecordsController(IMilitarySkillRecordService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSkillRecordsAsync()
        {
            var result = await _service.GetAllRecordsAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("personel/{personelId}/records")]
        public async Task<IActionResult> GetAllSkillRecordsByPersonelIdAsync(int personelId)
        {
            var result = await _service.GetAllRecordsByPersonelIdAsync(personelId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkillRecordByIdAsync(int id)
        {
            var result = await _service.GetRecordByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> AddSkillRecordAsync(MilitarySkillRecordAddDto dto)
        {
            var result = await _service.AddSkillRecordAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSkillRecordAsync(MilitarySkillRecordUpdateDto dto)
        {
            var result = await _service.UpdateSkillRecordAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkillRecordAsync(int id)
        {
            var result = await _service.DeleteSkillRecordAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
    }
}
