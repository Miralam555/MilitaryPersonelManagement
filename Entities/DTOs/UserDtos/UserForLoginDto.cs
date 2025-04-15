using Core.Entities;

namespace Entities.DTOs.UserDtos
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
