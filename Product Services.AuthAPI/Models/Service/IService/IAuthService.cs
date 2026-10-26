using Product_Services.AuthAPI.Models.Dto;
using Product_Services.AuthAPI.Models.DTO;

namespace Product_Services.AuthAPI.Models.Service.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<bool> AssignRole(string email, string roleName);
    }
}
