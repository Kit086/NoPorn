using Microsoft.AspNetCore.Mvc;
using NoPorn.Mvc.ApplicationService;
using NoPorn.Mvc.Models;
using NoPorn.Mvc.Repositories;

namespace NoPorn.Mvc.Controllers;
public class ImageController : Controller
{
    private readonly ILogger<ImageController> _logger;
    private readonly IImageAppService _imageAppService;
    private readonly IGirlRepository _girlRepository;
    private readonly IImageRepository _imageRepository;

    public ImageController(ILogger<ImageController> logger,
        IImageAppService imageAppService,
        IGirlRepository girlRepository,
        IImageRepository imageRepository)
    {
        _logger = logger;
        _imageAppService = imageAppService;
        _girlRepository = girlRepository;
        _imageRepository = imageRepository;
    }
    // GET: ImageController
    public ActionResult Index()
    {
        return View();
    }

    // GET: ImageController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: ImageController/Create
    public ActionResult Create(int girlId)
    {
        ViewBag.GirlId = girlId;
        return View();
    }

    // POST: ImageController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(ImageCreateViewModel imageCreateViewModel, [FromServices] IWebHostEnvironment webHostEnvironment)
    {
        if (!ModelState.IsValid)
        {
            return View(imageCreateViewModel);
        }
        try
        {
            var girl = await _girlRepository.GetGirlAsync(imageCreateViewModel.GirlId);
            if (girl is null)
            {
                throw new Exception($"不存在 Id 为 {imageCreateViewModel.GirlId} 的 Girl.");
            }
            var imageUrlList = await _imageAppService.UploadImagesForGirlAsync(girl.Id, webHostEnvironment.WebRootPath, imageCreateViewModel.Images);
            var imageList = new List<Image>();
            foreach (var url in imageUrlList)
            {
                var image = new Image
                {
                    Url = url,
                    GirlId = girl.Id,
                    Girl = girl,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    IsDeleted = false
                };
                imageList.Add(image);
            }
            await _imageRepository.CreateImagesAsync(imageList);
            return RedirectToAction("Details", "Girl", new { Id = girl.Id });
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to create Image.");
            return View("Error", new ErrorViewModel { ErrorMessage = e.Message });
        }
    }

    // GET: ImageController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: ImageController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: ImageController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: ImageController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
