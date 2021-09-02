
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
        var girl = await _dbContext.Girls.Include(g => g.Images).SingleOrDefaultAsync(g => g.Id == id);
        // var images = await _dbContext.Images.Where(i => i.GirlId == id).Select(i => i).ToListAsync();
        return girl;
    }
    public async Task<List<Girl>> GetAllGirlsAsync()
    {
        var girls = await _dbContext.Girls.ToListAsync();
        return girls;
    }

    public async Task<Girl> CreateGirlAsync(Girl girl)
    {
        var createdGirl = (await _dbContext.Girls.AddAsync(girl)).Entity;
        await _dbContext.SaveChangesAsync();
        return createdGirl;
    }

    public async Task<Girl> UpdateGirlAsync(Girl girl)
    {
        var updatedGirl = (_dbContext.Girls.Attach(girl)).Entity;
        await _dbContext.SaveChangesAsync();
        return updatedGirl;
    }
}
