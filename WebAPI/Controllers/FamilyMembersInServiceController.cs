using Business.Abstract;
using Entities.DTOs.FamilyMemberDtos;
using Entities.DTOs.FamilyMembersInServiceDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FamilyMembersInServiceController : ControllerBase
    {
        private readonly IFamilyMembersInService_Service _service;

        public FamilyMembersInServiceController(IFamilyMembersInService_Service service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllFamilyMembersInServiceAsync()
        {
            var result = await _service.GetAllFamilyMembersInService();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getallbypersonelid")]
        public async Task<IActionResult> GetAllFamilyMembersInServiceByPersonelIdAsync(int personelId)
        {
            var result = await _service.GetAllFamilyMembersInServiceByPersonelId(personelId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getallbymemberid")]
        public async Task<IActionResult> GetAllFamilyMembersInServiceByMemberId(int memberId)
        {
            var result = await _service.GetAllFamilyMembersInServiceByMemberId(memberId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdFamilyMemberInService(int id)
        {
            var result = await _service.GetByIdFamilyMemberInService(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddFamilyMembersInServiceAsync(FamilyMembersInServiceAddDto dto)
        {
            var result = await _service.AddFamilyMembersInService(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateFamilyMembersInServiceAsync(FamilyMembersInServiceUpdateDto dto)
        {
            var result = await _service.UpdateFamilyMembersInService(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
         [HttpPut("delete")]
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
