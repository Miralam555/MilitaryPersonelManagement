using Business.Abstract;
using Entities.DTOs.PersonelSpecialSkillDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonelSpecialSkillsController : ControllerBase
    {
        private readonly IMilitaryPersonelSpecialSkillService _service;

        public PersonelSpecialSkillsController(IMilitaryPersonelSpecialSkillService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSkillsAsync()
        {
            var result = await _service.GetAllSkillsAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("personel/{personelId}/skills")]
        public async Task<IActionResult> GetAllSkillsByPersonelIdAsync(int personelId)
        {
            var result = await _service.GetAllSkillsByPersonelIdAsync(personelId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkillByIdAsync(int id)
        {
            var result = await _service.GetSkillByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> AddSkillAsync(PersonelSpecialSkillAddDto dto)
        {
            var result = await _service.AddSkillAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSkillAsync(PersonelSpecialSkillUpdateDto dto)
        {
            var result = await _service.UpdateSkillAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkillAsync(int id)
        {
            var result = await _service.DeleteSkillAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
    }
}
