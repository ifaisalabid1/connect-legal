using System.ComponentModel.DataAnnotations;

namespace ConnectLegal.DTOs;

public class UserRegisterDto
{
    [Required, MaxLength(255)]
    public required string FirstName { get; set; }

    [Required, MaxLength(255)]
    public required string LastName { get; set; }

    [Required, EmailAddress, MaxLength(255)]
    public required string Email { get; set; }

    [Required, MaxLength(255)]
    public required string Password { get; set; }

    [Required, MaxLength(255)]
    public required string ConfirmPassword { get; set; }
}

public class UserLoginDto
{
    [Required, EmailAddress, MaxLength(255)]
    public required string Email { get; set; }

    [Required, MaxLength(255)]
    public required string Password { get; set; }
}

public class AuthResponseDto
{
    public required string Token { get; set; }
    public DateTime Expiration { get; set; }
    public UserProfileDto User { get; set; } = null!;
}

public class UserProfileDto
{
    [Key]
    public required string Id { get; set; }

    [Required, MaxLength(255)]
    public required string FirstName { get; set; }

    [Required, MaxLength(255)]
    public required string LastName { get; set; }

    [Required, EmailAddress, MaxLength(255)]
    public required string Email { get; set; }
    public string FullName => $"{FirstName} {LastName}";
}

public class ChangePasswordDto
{
    [Required, MaxLength(255)]
    public required string CurrentPassword { get; set; }

    [Required, MaxLength(255)]
    public required string NewPassword { get; set; }

    [Required, MaxLength(255)]
    public required string ConfirmNewPassword { get; set; }
}