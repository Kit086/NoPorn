
using NoPorn.Mvc.Models;

namespace NoPorn.Mvc.Repositories;
public class ImageRepository : IImageRepository
{
    private readonly AppDbContext _dbContext;

    public ImageRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}
