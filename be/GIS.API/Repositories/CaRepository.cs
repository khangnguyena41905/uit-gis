using GIS.API.Abstractions;
using GIS.API.Models;

namespace GIS.API.Repositories;

public interface ICaRepository : IRepositoryBase<Ca, int>
{
}

public class CaRepository : RepositoryBase<Ca, int>, ICaRepository
{
    public CaRepository(ApplicationDbContext context) : base(context)
    {
    }
}