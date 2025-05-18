using Business.Abstract;
using Entities.DTOs.FamilyMemberDtos;
using Entities.DTOs.FamilyMembersInServiceDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FamilyMembersInServiceController : ControllerBase
    {
        private readonly IFamilyMembersInService_Service _service;

        public FamilyMembersInServiceController(IFamilyMembersInService_Service service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFamilyMembersInServiceAsync()
        {
            var result = await _service.GetAllFamilyMembersInService();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("personel/{personelId}/familymembers")]
        public async Task<IActionResult> GetAllFamilyMembersInServiceByPersonelIdAsync(int personelId)
        {
            var result = await _service.GetAllFamilyMembersInServiceByPersonelId(personelId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("member/{memberId}/familymembers")]
        public async Task<IActionResult> GetAllFamilyMembersInServiceByMemberIdAsync(int memberId)
        {
            var result = await _service.GetAllFamilyMembersInServiceByMemberId(memberId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdFamilyMemberInServiceAsync(int id)
        {
            var result = await _service.GetByIdFamilyMemberInService(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> AddFamilyMembersInServiceAsync(FamilyMembersInServiceAddDto dto)
        {
            var result = await _service.AddFamilyMembersInService(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFamilyMembersInServiceAsync(FamilyMembersInServiceUpdateDto dto)
        {
            var result = await _service.UpdateFamilyMembersInService(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
         [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFamilyMembersInServiceAsync(int id)
        {
            var result = await _service.DeleteFamilyMembersInService(id);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }

    }
}
