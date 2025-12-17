using GIS.API.Abstractions;
using Newtonsoft.Json;

namespace GIS.API.Models;

public class User : DomainEntity<int>
{
    public string Name { get; private set; }
    public string? Code { get; private set; }
    public string Email { get; private set; }
    public string UserName { get; private set; }
    [JsonIgnore]
    public string Password { get; private set; }
    public string Phone { get; private set; }
    public string PositionId { get; private set; }
    public bool IsActive { get; private set; }
    public bool IsAdmin { get; private set; }
    public virtual Position Position { get; set; }
    private User(){}
    
    public User(string name, string email, string username, string password, string phone,  string positionId, bool? isActive = true)
    {
        Name = name;
        Email = email;
        UserName = username;
        Password = password;
        Phone = phone;
        PositionId = positionId;
        IsActive = isActive ?? true;
        IsAdmin = false;
    }

    public void UpdateCode()
    {
        var departmentCode = Position.Department.Code;
        Code = departmentCode.ToUpper() + Id.ToString("D4");
    }
    
    public void UpdateBaseInfo(string name, string email, string phone, string positionId)
    {
        Name = name;
        Email = email;
        Phone = phone;
        PositionId = positionId;
    }
    
    public void UpdatePassword(string password)
    {
        Password = password;
    }
}