using GIS.API.Abstractions;

namespace GIS.API.Models;

public class Position : DomainEntity<string>
{
    public string Name { get; private set; }
    public string Code { get; private set; }
    public string DepartmentId { get; private set; }
    public virtual Department Department { get; set; }
    private Position(){}
    public Position(string name, string code, string departmentId)
    {
        Name = name;
        Code = code;
        DepartmentId = departmentId;
    }
}