using Microsoft.AspNetCore.Mvc;
using NoPorn.Mvc.ApplicationService;
using NoPorn.Mvc.Models;
using NoPorn.Mvc.Repositories;

namespace NoPorn.Mvc.Controllers;
public class GirlController : Controller
{
    private readonly ILogger<GirlController> _logger;
    private readonly IConfiguration _configuration;
    private readonly IGirlRepository _girlRepository;
    private readonly IImageAppService _imageAppService;

    public GirlController(ILogger<GirlController> logger, 
        IConfiguration configuration, 
        IGirlRepository girlRepository,
        IImageAppService imageAppService)
    {
        _logger = logger;
        _configuration = configuration;
        _girlRepository = girlRepository;
        _imageAppService = imageAppService;
    }
    // GET: GirlController
    public async Task<IActionResult> Index()
    {
        var girls = await _girlRepository.GetAllGirlsAsync();
        foreach (var girl in girls)
        {
            girl.AvatarUrl = _configuration["Url"] + girl.AvatarUrl;
        }
        return View(girls);
    }

    // GET: GirlController/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var girl = await _girlRepository.GetGirlAsync(id);
        girl.AvatarUrl = _configuration["Url"] + girl.AvatarUrl;
        foreach (var image in girl.Images)
        {
            image.Url = _configuration["Url"] + image.Url;
        }
        return View(girl);
    }


    // GET: GirlController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: GirlController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(GirlCreateViewModel girlCreateViewModel, [FromServices] IWebHostEnvironment webHostEnvironment)
    {
        if (!ModelState.IsValid)
        {
            return View(girlCreateViewModel);
        }
        try
        {
            var newGirl = new Girl
            {
                Name = girlCreateViewModel.Name,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                IsDeleted = false
            };
            var createdGirl = await _girlRepository.CreateGirlAsync(newGirl);
            createdGirl.AvatarUrl = await _imageAppService.UploadImageForGirlAsync(createdGirl.Id, webHostEnvironment.WebRootPath, girlCreateViewModel.Avatar);
            await _girlRepository.UpdateGirlAsync(createdGirl);
            // updatedGirl.AvatarUrl = _configuration["Url"] + updatedGirl.AvatarUrl;
            return RedirectToAction("Details", "Girl", new { Id = createdGirl.Id });
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to create Girl.");
            return View("Error", new ErrorViewModel { ErrorMessage = e.Message });
        }
    }

    // GET: GirlController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: GirlController/Edit/5
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

    // GET: GirlController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: GirlController/Delete/5
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
