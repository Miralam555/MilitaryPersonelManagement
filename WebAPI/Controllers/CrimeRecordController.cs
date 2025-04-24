using Business.Abstract;
using Entities.DTOs.CrimeRecordDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CrimeRecordController : ControllerBase
    {
        private readonly ICrimeRecordService _service;

        public CrimeRecordController(ICrimeRecordService service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllCrimeRecords()
        {
            var result=await _service.GetAllCrimeRecordsAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }
        [HttpGet("getbypersonelid")]
        public async Task<IActionResult> GetCrimeRecordByPersonelId(int id)
        {
            var result=await _service.GetCrimeRecordsByPersonelIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }
        [HttpGet("getbymemberid")]
        public async Task<IActionResult> GetCrimeRecordByMemberId(int id)
        {
            var result=await _service.GetCrimeRecordsByMemberIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCrimeRecordAsync(CrimeRecordAddDto dto)
        {
            var result=await _service.AddCrimeRecordAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
         [HttpPut("update")]
        public async Task<IActionResult> UpdateCrimeRecordAsync(CrimeRecordUpdateAndGetDto dto)
        {
            var result=await _service.UpdateCrimeRecordAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpDelete("delete")]
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
