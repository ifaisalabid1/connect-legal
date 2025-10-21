using AutoMapper;
using ConnectLegal.DTOs;
using ConnectLegal.Entities;
using ConnectLegal.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ConnectLegal.Services;

public class AuthService(UserManager<User> userManager, ITokenService tokenService, IMapper mapper) : IAuthService
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly ITokenService _tokenService = tokenService;
    private readonly IMapper _mapper = mapper;

    public async Task<AuthResponseDto> RegisterAsync(UserRegisterDto registerDto)
    {
        if (registerDto.Password != registerDto.ConfirmPassword)
        {
            throw new ArgumentException("Password and confirmation password do not match.");
        }

        var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
        if (existingUser != null)
        {
            throw new InvalidOperationException("User with this email already exists.");
        }

        var user = new User
        {
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            Email = registerDto.Email,
            UserName = registerDto.Email
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new InvalidOperationException($"User creation failed: {errors}");
        }

        // Add user to basic role
        await _userManager.AddToRoleAsync(user, "User");

        var token = _tokenService.GenerateToken(user);
        var userProfile = _mapper.Map<UserProfileDto>(user);

        return new AuthResponseDto
        {
            Token = token,
            Expiration = DateTime.Now.AddMinutes(60),
            User = userProfile
        };
    }

    public async Task<AuthResponseDto> LoginAsync(UserLoginDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
        {
            throw new UnauthorizedAccessException("Invalid email or password.");
        }

        if (!user.IsActive)
        {
            throw new UnauthorizedAccessException("Account is deactivated.");
        }

        var token = _tokenService.GenerateToken(user);
        var userProfile = _mapper.Map<UserProfileDto>(user);

        return new AuthResponseDto
        {
            Token = token,
            Expiration = DateTime.Now.AddMinutes(60),
            User = userProfile
        };
    }

    public async Task<UserProfileDto> GetUserProfileAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId) ?? throw new KeyNotFoundException("User not found.");
        return _mapper.Map<UserProfileDto>(user);
    }

    public async Task ChangePasswordAsync(string userId, ChangePasswordDto changePasswordDto)
    {
        if (changePasswordDto.NewPassword != changePasswordDto.ConfirmNewPassword)
        {
            throw new ArgumentException("New password and confirmation password do not match.");
        }

        var user = await _userManager.FindByIdAsync(userId) ?? throw new KeyNotFoundException("User not found.");

        var result = await _userManager.ChangePasswordAsync(
            user,
            changePasswordDto.CurrentPassword,
            changePasswordDto.NewPassword);

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new InvalidOperationException($"Password change failed: {errors}");
        }

        user.UpdatedAt = DateTime.Now;
        await _userManager.UpdateAsync(user);
    }
}