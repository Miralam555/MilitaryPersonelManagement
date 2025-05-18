using Business.Abstract;
using Entities.DTOs.PersonelForeignLanguageLevel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PersonelForeignLanguageLevelsController : ControllerBase
    {
        private readonly IMilitaryPersonelForeignLanguageLevelService _service;

        public PersonelForeignLanguageLevelsController(IMilitaryPersonelForeignLanguageLevelService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _service.GetAllLevelAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("injunction/{injunctionId}/levels")]
        public async Task<IActionResult> GetAllByInjunctionIdAsync(int injunctionId)
        {
            var result = await _service.GetAllLevelByInjunctionIdAsync(injunctionId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("personel/{personelId}/levels")]
        public async Task<IActionResult> GetAllByPersonelIdAsync(int personelId)
        {
            var result = await _service.GetAllLevelByPersonelIdAsync(personelId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _service.GetLevelByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(PersonelForeignLanguageLevelAddDto dto)
        {
            var result = await _service.AddLevelAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(PersonelForeignLanguageLevelUpdateDto dto)
        {
            var result = await _service.UpdateLevelAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

    }
}
