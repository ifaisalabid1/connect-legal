using ConnectLegal.Entities;

namespace ConnectLegal.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}