using System.ComponentModel.DataAnnotations;

namespace GIS.API.DependencyInjections.Options;

public class JwtSettings
{
    [Required] public string Key { get; set; } = default!;
    [Required] public string Issuer { get; set; } = default!;
    [Required] public string Audience { get; set; } = default!;
    public int ExpireMinutes { get; set; }
}
