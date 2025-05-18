using Business.Abstract;
using Core.Entities;
using Entities.DTOs.PersonelForeignTravelDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PersonelForeignTravelsController : ControllerBase
    {
        private readonly IMilitaryPersonelForeignTravelService _service;

        public PersonelForeignTravelsController(IMilitaryPersonelForeignTravelService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTravelsAsync()
        {
            var result = await _service.GetAllTravelsAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("injunction/{injunctionId}/travels")]
        public async Task<IActionResult> GetAllTravelsByInjunctionIdAsync(int injunctionId)
        {
            var result = await _service.GetAllTravelsByInjunctionIdAsync(injunctionId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("personel/{personelId}/travels")]
        public async Task<IActionResult> GetAllTravelsByPersonelIdAsync(int personelId)
        {
            var result = await _service.GetAllTravelsByPersonelIdAsync(personelId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> AddTravelAsync(PersonelForeignTravelAddDto dto)
        {
            var result = await _service.AddTravelAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTravelAsync(PersonelForeignTravelUpdateDto dto)
        {
            var result = await _service.UpdateTravelAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTravelsAsync(int id)
        {
            var result = await _service.DeleteTravelAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
