
using NoPorn.Mvc.ApplicationService;
using NoPorn.Mvc.Models;

namespace NoPorn.Mvc.ApplicationHelper;
public class ImageAppService : IImageAppService
{
    public async Task<string> UploadImageForGirlAsync(int girlId, string webRootPath, IFormFile file)
    {
        var folderRelativePath = $"images/{girlId}";
        var fileName = $"{Guid.NewGuid()}_{file.FileName}";
        var fileRelativePath = $"{folderRelativePath}/{fileName}";
        await UploadImageAsync(folderRelativePath, webRootPath, file, fileName);
        return fileRelativePath;
    }

    public async Task<List<string>> UploadImagesForGirlAsync(int girlId, string webRootPath, IList<IFormFile> fileList)
    {
        var folderRelativePath = $"images/{girlId}";
        var taskList = new List<Task>();
        var fileRelativePathList = new List<string>();
        foreach (var file in fileList)
        {
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            fileRelativePathList.Add($"{folderRelativePath}/{fileName}");
            taskList.Add(UploadImageAsync(folderRelativePath, webRootPath, file, fileName));
        }
        await Task.WhenAll(taskList.ToArray());

        return fileRelativePathList;
    }

    private async Task UploadImageAsync(string folderRelativePath, string webRootPath, IFormFile file, string fileName)
    {
        var folderAbsolutePath = Path.Combine(webRootPath, folderRelativePath);
        if (!Directory.Exists(folderAbsolutePath))
        {
            Directory.CreateDirectory(folderAbsolutePath);
        }
        // var fileRelativePath = $"{folderRelativePath}/{fileName}";
        var fileAbsolutePath = $"{folderAbsolutePath}/{fileName}";
        using var stream = System.IO.File.Create(fileAbsolutePath);
        await file.CopyToAsync(stream);
    }
}
