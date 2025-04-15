using Business.Abstract;
using Entities.DTOs.InjunctionDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class InjunctionController : Controller
    {
        private readonly IInjunctionService _service;

        public InjunctionController(IInjunctionService service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllInjunctions()
        {
            var result = await _service.GetAllInjunctionsAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdInjunctionsAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getallbypersonelid")]
        public async Task<IActionResult> GetByPersonelId(int id)
        {
            var result = await _service.GetAllInjunctionsByIssuedPersonelIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddInjunction(InjunctionAddDto dto)
        {
            var result = await _service.AddInjunctionAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);

            }
            return BadRequest();
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateInjunction(InjunctionUpdateAndGetDto dto)
        {
            var result = await _service.UpdateInjunctionAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);

            }
            return BadRequest();
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteInjunction(int id)
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
