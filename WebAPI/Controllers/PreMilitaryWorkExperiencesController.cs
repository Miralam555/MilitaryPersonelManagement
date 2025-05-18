using Business.Abstract;
using Core.Utilities.Results;
using Entities.DTOs.PreMilitaryWorkExperienceDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PreMilitaryWorkExperiencesController : ControllerBase
    {
        private readonly IPreMilitaryWorkExperienceService _service;

        public PreMilitaryWorkExperiencesController(IPreMilitaryWorkExperienceService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllExperiencesAsync()
        {
            var list = await _service.GetAllExperiencesAsync();
            if (list.IsSuccess)
            {
                return Ok(list.Data);
            }
            return BadRequest(list.Message);
        }
        [HttpGet("personel/{personelId}/experiences")]
        public async Task<IActionResult> GetAllExperiencesByPersonelIdAsync(int personelId)
        {
            var result = await _service.GetAllExperiencesByPersonelIdAsync(personelId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExperienceByIdAsync(int id)
        {
            var result = await _service.GetExperienceByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> AddExperienceAsync(PreMilitaryWorkExperienceAddDto dto)
        {
            var result = await _service.AddExperienceAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateExperienceAsync(PreMilitaryWorkExperienceUpdateDto dto)
        {
            var result = await _service.UpdateExperienceAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExperienceAsync(int id)
        {
            var result = await _service.DeleteExperienceAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
    }
}
