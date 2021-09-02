
using NoPorn.Mvc.Models;

namespace NoPorn.Mvc.ApplicationService;
public interface IImageAppService
{
    /// <summary>
    /// 上传单张图片
    /// </summary>
    /// <param name="girlId"></param>
    /// <param name="webRootPath"></param>
    /// <param name="file"></param>
    /// <returns></returns>
    Task<string> UploadImageForGirlAsync(int girlId, string webRootPath, IFormFile file);
    /// <summary>
    /// 上传多张图片
    /// </summary>
    /// <param name="girlId"></param>
    /// <param name="webRootPath"></param>
    /// <param name="fileList"></param>
    /// <returns></returns>
    Task<List<string>> UploadImagesForGirlAsync(int girlId, string webRootPath, IList<IFormFile> fileList);
}
