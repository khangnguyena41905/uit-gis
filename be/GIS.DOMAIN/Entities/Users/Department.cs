using GIS.DOMAIN.Abstractions;

namespace GIS.DOMAIN.Entities.Users;

public class Department: DomainEntity<string>
{
    public string Name { get; private set; }
    public string Code { get; private set; }
    private Department(){}
    public Department(string id,string name, string code)
    {
        Id = id;
        Name = name;
        Code = code;
    }
}