namespace GIS.API.Commons.Abstractions
{
    public interface ICurrentUser
    {
        string? UserName { get; }
    }

    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _http;

        public CurrentUser(IHttpContextAccessor http)
        {
            _http = http;
        }

        public string? UserName =>
            _http.HttpContext?.User?.Identity?.Name;
    }
}