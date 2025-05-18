using Business.Abstract;
using Entities.DTOs.CrimeRecordDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CrimeRecordsController : ControllerBase
    {
        private readonly ICrimeRecordService _service;

        public CrimeRecordsController(ICrimeRecordService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCrimeRecordsAsync()
        {
            var result=await _service.GetAllCrimeRecordsAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("personel/{personelId}/crimes")]
        public async Task<IActionResult> GetCrimeRecordByPersonelIdAsync(int personelId)
        {
            var result=await _service.GetCrimeRecordsByPersonelIdAsync(personelId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("familymember/{memberId}/crimes")]
        public async Task<IActionResult> GetCrimeRecordsByMemberIdAsync(int memberId)
        {
            var result=await _service.GetCrimeRecordsByMemberIdAsync(memberId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
         [HttpGet("{id}")]
        public async Task<IActionResult> GetCrimeRecordByIdAsync(int id)
        {
            var result=await _service.GetCrimeRecordByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> AddCrimeRecordAsync(CrimeRecordAddDto dto)
        {
            var result=await _service.AddCrimeRecordAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
         [HttpPut]
        public async Task<IActionResult> UpdateCrimeRecordAsync(CrimeRecordUpdateDto dto)
        {
            var result=await _service.UpdateCrimeRecordAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCrimeRecordAsync(int id)
        {
            var result = await _service.DeleteCrimeRecordAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }

    }
}
