using ConnectLegal.DTOs;

namespace ConnectLegal.Interfaces;

public interface IAuthService
{
    Task<AuthResponseDto> RegisterAsync(UserRegisterDto registerDto);
    Task<AuthResponseDto> LoginAsync(UserLoginDto loginDto);
    Task<UserProfileDto> GetUserProfileAsync(string userId);
    Task ChangePasswordAsync(string userId, ChangePasswordDto changePasswordDto);
}