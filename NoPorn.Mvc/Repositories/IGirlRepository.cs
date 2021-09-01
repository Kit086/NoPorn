
using NoPorn.Mvc.Models;

namespace NoPorn.Mvc.Repositories;
public interface IGirlRepository
{

    Task<int> CountAsync();
    Task<Girl> GetGirlAsync(int id);
    Task<List<Girl>> GetAllGirlsAsync();
    Task<Girl> CreateGirlAsync(Girl girl);
    Task<Girl> UpdateGirlAsync(Girl girl);
}
