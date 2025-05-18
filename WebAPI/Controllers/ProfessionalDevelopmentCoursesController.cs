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
    public class ProfessionalDevelopmentCoursesController : ControllerBase
    {
        private readonly IProfessionalDevelopomentCourseService _service;

        public ProfessionalDevelopmentCoursesController(IProfessionalDevelopomentCourseService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCoursesAsync()
        {
            var result = await _service.GetAllCoursesAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
         [HttpGet("personel/{personelId}/courses")]
        public async Task<IActionResult> GetAllCoursesByPersonelIdAsync(int personelId)
        {
            var result = await _service.GetAllCoursesByPersonelIdAsync(personelId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
         [HttpGet("injunction/{injunctionId}/courses")]
        public async Task<IActionResult> GetAllCoursesByInjunctionIdAsync(int injunctionId)
        {
            var result = await _service.GetAllCoursesByInjunctionIdAsync(injunctionId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
         [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseByIdAsync(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> AddCourseAsync(ProfessionalDevelopmentCourseAddDto dto)
        {
            var result = await _service.AddCourseAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCourseAsync(ProfessionalDevelopmentCourseUpdateDto dto)
        {
            var result = await _service.UpdateCourseAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
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
