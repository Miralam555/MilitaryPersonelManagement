using Business.Abstract;
using Entities.DTOs.MilitaryPersonelDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MilitaryPersonelController : ControllerBase
    {
        private readonly IMilitaryPersonelService _service;
        public MilitaryPersonelController(IMilitaryPersonelService service)
        {
            _service = service;
        }
        [HttpPost("addpersonel")]
        public async Task<IActionResult> AddPersonelAsync(MilitaryPersonelAddDto dto)
        {
            var result=await _service.PersonelAddAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPut("updatepersonel")]
        public async Task<IActionResult> UpdatePersonelAsync(MilitaryPersonelUpdateDto dto)
        {
            var result = await _service.PersonelUpdateAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getallpersonels")]
        public async Task<IActionResult> GetPersonelsAsync()
        {
            var result=await _service.GetAllPersonelAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyidpersonel")]
        public async Task<IActionResult> GetPersonelByIdAsync(int id)
        {
            var result = await _service.GetByIdPersonel(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
