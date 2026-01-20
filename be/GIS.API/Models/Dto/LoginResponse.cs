namespace GIS.API.Models.Dto;

public class LoginResponse
{
    public string TokenType { get; set; } = String.Empty;
    public string Token { get; set; } = String.Empty;
    public DateTime ExpiresIn { get; set; }
    public string HoTen { get; set; } = String.Empty;
    public string UserName { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public int NhanVienId { get; set; }
    public int RoleId { get; set; }
    public string RoleCode { get; set; }
    
}