using Business.Abstract;
using Entities.DTOs.InjunctionDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class InjunctionsController : ControllerBase
    {
        private readonly IInjunctionService _service;

        public InjunctionsController(IInjunctionService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllInjunctionsAsync()
        {
            var result = await _service.GetAllInjunctionsAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _service.GetInjunctionByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("personel/{personelId}/injunctions")]
        public async Task<IActionResult> GetByPersonelIdAsync(int id)
        {
            var result = await _service.GetAllInjunctionsByIssuedPersonelIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> AddInjunctionAsync(InjunctionAddDto dto)
        {
            var result = await _service.AddInjunctionAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);

            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateInjunctionAsync(InjunctionUpdateDto dto)
        {
            var result = await _service.UpdateInjunctionAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);

            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInjunctionAsync(int id)
        {
            var result = await _service.DeleteInjunctionAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Message);

            }
            return BadRequest();
        }

    }
}
