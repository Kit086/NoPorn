
using Microsoft.EntityFrameworkCore;
using NoPorn.Mvc.Models;

namespace NoPorn.Mvc.Repositories;
public class GirlRepository : IGirlRepository
{
    private readonly AppDbContext _dbContext;

    public GirlRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CountAsync()
    {
        return await _dbContext.Girls.CountAsync();
    }

    public async Task<Girl> GetGirlAsync(int id)
    {
        var girls = await _dbContext.Girls.Include(g => g.Images).SingleOrDefaultAsync(g => g.Id == id);
        // var images = await _dbContext.Images.Where(i => i.GirlId == id).Select(i => i).ToListAsync();
        return girls;
    }
}
