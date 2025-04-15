using Business.Abstract;
using Entities.DTOs.FamilyMemberDtos;
using Entities.DTOs.FamilyMembersInServiceDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FamilyMembersInServiceController : Controller
    {
        private readonly IFamilyMembersInService_Service _service;

        public FamilyMembersInServiceController(IFamilyMembersInService_Service service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddFamilyMembersInServiceAsync(FamilyMembersInServiceAddDto dto)
        {
            var result = await _service.AddFamilyMembersInService(dto);
            if (result.IsSuccess)
            {
               return  Ok(result.Message);
            }
            return BadRequest();
        }
    }
}
