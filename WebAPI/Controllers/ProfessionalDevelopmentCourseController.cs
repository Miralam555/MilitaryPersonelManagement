using Business.Abstract;
using Entities.DTOs.ProfessionalDevelopmentCourse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfessionalDevelopmentCourseController : ControllerBase
    {
        private readonly IProfessionalDevelopomentCourseService _service;

        public ProfessionalDevelopmentCourseController(IProfessionalDevelopomentCourseService service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllCoursesAsync()
        {
            var result = await _service.GetAllCoursesAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
         [HttpGet("getallbypersonelid")]
        public async Task<IActionResult> GetAllCoursesByPersonelIdAsync(int personelId)
        {
            var result = await _service.GetAllCoursesByPersonelIdAsync(personelId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
         [HttpGet("getallbyinjunctionid")]
        public async Task<IActionResult> GetAllCoursesByInjunctionIdAsync(int injunctionId)
        {
            var result = await _service.GetAllCoursesByInjunctionIdAsync(injunctionId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
         [HttpGet("getbyid")]
        public async Task<IActionResult> GetCourseByIdAsync(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddCourseAsync(ProfessionalDevelopmentCourseAddDto dto)
        {
            var result = await _service.AddCourseAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateCourseAsync(ProfessionalDevelopmentCourseUpdateDto dto)
        {
            var result = await _service.UpdateCourseAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCourseAsync(int id)
        {
            var result = await _service.DeleteCourseAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
