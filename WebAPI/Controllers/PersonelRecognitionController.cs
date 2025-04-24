using Business.Abstract;
using Entities.DTOs.MilitaryPersonelRecognitionDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonelRecognitionController : ControllerBase
    {
        private readonly IMilitaryPersonelRecognitionService _service;

        public PersonelRecognitionController(IMilitaryPersonelRecognitionService service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllRecognitionsAsync()
        {
            var result = await _service.GetAllRecognitionsAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getallbyinjunctionid")]
        public async Task<IActionResult> GetAllRecognitionsByInjunctionIdAsync(int injunctionId)
        {
            var result = await _service.GetAllRecognitionsByInjunctionIdAsync(injunctionId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getallbypersonelid")]
        public async Task<IActionResult> GetAllRecognitionsByPersonelIdAsync(int personelId)
        {
            var result = await _service.GetAllRecognitionsByPersonelIdAsync(personelId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetRecognitionByIdAsync(int id)
        {
            var result = await _service.GetRecognitionByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddRecognitionAsync(PersonelRecognitionAddDto dto)
        {
            var result = await _service.AddRecognitionAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);

            }
            return BadRequest(result.Message);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateRecognitionAsync(PersonelRecognitionUpdateDto dto)
        {
            var result = await _service.UpdateRecognitionAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);

            }
            return BadRequest(result.Message);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteRecognitionAsync(int id)
        {
            var result = await _service.DeleteRecognitionAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
