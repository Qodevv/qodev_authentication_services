using Microsoft.AspNetCore.Identity;

namespace qodev_authentication_services.utils.jwt;

public class JWTIdentity : IdentityUser
{
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}