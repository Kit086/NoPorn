
using NoPorn.Mvc.Models;

namespace NoPorn.Mvc.Repositories;
public class ImageRepository : IImageRepository
{
    private readonly AppDbContext _dbContext;

    public ImageRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Image> CreateImageAsync(Image image)
    {
        var createdImage = (await _dbContext.Images.AddAsync(image)).Entity;
        await _dbContext.SaveChangesAsync();
        return createdImage;
    }

    public async Task CreateImagesAsync(IList<Image> images)
    {
        await _dbContext.Images.AddRangeAsync(images);
        await _dbContext.SaveChangesAsync();
    }
}
