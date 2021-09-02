
using NoPorn.Mvc.Models;

namespace NoPorn.Mvc.Repositories;
public interface IImageRepository
{
    /// <summary>
    /// 创建图片
    /// </summary>
    /// <param name="image"></param>
    /// <returns></returns>
    Task<Image> CreateImageAsync(Image image);
    /// <summary>
    /// 批量创建图片
    /// </summary>
    /// <param name="images"></param>
    /// <returns></returns>
    Task CreateImagesAsync(IList<Image> images);
}
