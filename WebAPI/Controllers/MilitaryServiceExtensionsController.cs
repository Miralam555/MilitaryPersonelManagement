using Business.Abstract;
using Core.Entities;
using Entities.DTOs.MilitaryServiceExtensionDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MilitaryServiceExtensionsController : ControllerBase
    {
        private readonly IMilitaryServiceExtensionService _service;

        public MilitaryServiceExtensionsController(IMilitaryServiceExtensionService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllExtensionsAsync()
        {
            var result = await _service.GetAllExtensionsAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("personel/{personelId}/extensions")]
        public async Task<IActionResult> GetAllExtensionsByPersonelIdAsync(int personelId)
        {
            var result = await _service.GetAllExtensionsByPersonelIdAsync(personelId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("injunction/{injunctionId}/extensions")]
        public async Task<IActionResult> GetAllExtensionsByInjunctionIdAsync(int injunctionId)
        {
            var result = await _service.GetAllExtensionsByInjunctionIdAsync(injunctionId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExtensionByIdAsync(int id)
        {
            var result = await _service.GetExtensionByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> AddExtensionAsync(MilitaryServiceExtensionAddDto dto)
        {
            var result = await _service.AddExtensionASync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateExtensionAsync(MilitaryServiceExtensionUpdateDto dto)
        {
            var result = await _service.UpdateExtensionAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExtensionAsync(int id)
        {
            var result = await _service.DeleteExtensionAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
    }
}
