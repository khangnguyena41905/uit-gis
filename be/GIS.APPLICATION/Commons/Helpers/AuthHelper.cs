using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using GIS.DOMAIN.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GIS.APPLICATION.Commons.Helpers;

public interface IAuthHelper
{
    string HashPassword(string password);
    bool VerifyPassword(string password, string passwordHash);
    (string, DateTime)  GenerateJwtToken(int userId, string userName, IEnumerable<string>? roles = null);
}

public class AuthHelper : IAuthHelper
{
    private readonly JwtSettings _jwtSettings;

    public AuthHelper(IOptions<JwtSettings> options)
    {
        _jwtSettings = options.Value;
    }
    
    public string HashPassword(string password)
    {
        using var rng = RandomNumberGenerator.Create();
        var salt = new byte[16];
        rng.GetBytes(salt);

        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256);
        
        var hash = pbkdf2.GetBytes(32);

        return $"{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
    }

    // =========================
    // VERIFY PASSWORD
    // =========================
    public bool VerifyPassword(string password, string passwordHash)
    {
        var parts = passwordHash.Split('.');
        if (parts.Length != 2)
            return false;

        var salt = Convert.FromBase64String(parts[0]);
        var hash = Convert.FromBase64String(parts[1]);

        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256);

        var computedHash = pbkdf2.GetBytes(32);

        return CryptographicOperations.FixedTimeEquals(hash, computedHash);
    }

    // =========================
    // GENERATE JWT TOKEN
    // =========================
    public (string, DateTime) GenerateJwtToken(
        int userId,
        string userName,
        IEnumerable<string>? roles = null)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(ClaimTypes.Name, userName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        if (roles != null)
        {
            claims.AddRange(
                roles.Select(role => new Claim(ClaimTypes.Role, role)));
        }

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwtSettings.Key));

        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256);

        var experied = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpireMinutes);
        
        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: experied,
            signingCredentials: credentials
        );

        return (new JwtSecurityTokenHandler().WriteToken(token), experied);
    }
}