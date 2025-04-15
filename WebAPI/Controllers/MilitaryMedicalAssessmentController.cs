using Business.Abstract;
using Core.Utilities.Results;
using Entities.DTOs.MilitaryMedicalAssessmentDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MilitaryMedicalAssessmentController : Controller
    {
        private readonly IMilitaryMedicalAssessmentService _service;

        public MilitaryMedicalAssessmentController(IMilitaryMedicalAssessmentService service)
        {
            _service = service;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _service.GetAllAsync();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getallbypersonelid")]
        public async Task<IActionResult> GetAllByPersonelIdAsync(int id)
        {
            var result=await _service.GetAllByPersonelIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(MilitaryMedicalAssessmentAddDto dto)
        {
           
            var result = await _service.AddAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync(MilitaryMedicalAsssessmentGetDto dto)
        {
            var result = await _service.UpdateAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
