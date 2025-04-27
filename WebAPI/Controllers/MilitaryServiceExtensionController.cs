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
    public class MilitaryServiceExtensionController : ControllerBase
    {
        private readonly IMilitaryServiceExtensionService _service;

        public MilitaryServiceExtensionController(IMilitaryServiceExtensionService service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllExtensionsAsync()
        {
            var result = await _service.GetAllExtensionsAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getallbypersonelid")]
        public async Task<IActionResult> GetAllExtensionsByPersonelIdAsync(int personelId)
        {
            var result = await _service.GetAllExtensionsByPersonelIdAsync(personelId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getallbyinjunctionid")]
        public async Task<IActionResult> GetAllExtensionsByInjunctionIdAsync(int injunctionId)
        {
            var result = await _service.GetAllExtensionsByInjunctionIdAsync(injunctionId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetExtensionByIdAsync(int id)
        {
            var result = await _service.GetExtensionByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddExtensionAsync(MilitaryServiceExtensionAddDto dto)
        {
            var result = await _service.AddExtensionASync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateExtensionAsync(MilitaryServiceExtensionUpdateDto dto)
        {
            var result = await _service.UpdateExtensionAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpDelete("delete")]
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
