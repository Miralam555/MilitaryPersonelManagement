using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MilitaryPersonelPenaltyController : Controller
    {
        public IMilitaryPersonelPenaltyService _service;

        public MilitaryPersonelPenaltyController(IMilitaryPersonelPenaltyService service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllPenaltiesAsync()
        {
            var result = await _service.GetAllPenaltiesAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
