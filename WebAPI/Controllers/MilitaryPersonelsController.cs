using Business.Abstract;
using Entities.DTOs.MilitaryPersonelDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MilitaryPersonelsController : ControllerBase
    {
        private readonly IMilitaryPersonelService _service;
        public MilitaryPersonelsController(IMilitaryPersonelService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> AddPersonelAsync(MilitaryPersonelAddDto dto)
        {
            var result=await _service.PersonelAddAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePersonelAsync(MilitaryPersonelUpdateDto dto)
        {
            var result = await _service.PersonelUpdateAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpGet]
        public async Task<IActionResult> GetPersonelsAsync()
        {
            var result=await _service.GetAllPersonelAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("{id}")]
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
