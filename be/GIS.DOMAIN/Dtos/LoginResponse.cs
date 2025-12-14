namespace GIS.DOMAIN.Dtos;

public class LoginResponse
{
    public string TokenType { get; set; }
    public string Token { get; set; }
    public DateTime ExpiresIn { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
}