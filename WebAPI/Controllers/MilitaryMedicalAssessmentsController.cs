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
    public class MilitaryMedicalAssessmentsController : ControllerBase
    {
        private readonly IMilitaryMedicalAssessmentService _service;

        public MilitaryMedicalAssessmentsController(IMilitaryMedicalAssessmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsyncAsync()
        {
            var result = await _service.GetAllAssessmentsAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("personel/{id}/medicalassessments")]
        public async Task<IActionResult> GetAllByPersonelIdAsync(int id)
        {
            var result=await _service.GetAllAssessmentsByPersonelIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _service.GetAssessmentByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(MilitaryMedicalAssessmentAddDto dto)
        {
           
            var result = await _service.AddAssessmentAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(MilitaryMedicalAssessmentUpdateDto dto)
        {
            var result = await _service.UpdateAssesmentAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _service.DeleteAssesmentAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }

    }
}
