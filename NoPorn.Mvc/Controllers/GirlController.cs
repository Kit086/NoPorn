using Microsoft.AspNetCore.Mvc;
using NoPorn.Mvc.Models;
using NoPorn.Mvc.Repositories;

namespace NoPorn.Mvc.Controllers;
public class GirlController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly IGirlRepository _girlRepository;

    public GirlController(IConfiguration configuration, IGirlRepository girlRepository)
    {
        _configuration = configuration;
        _girlRepository = girlRepository;
    }
    // GET: GirlController
    public async Task<IActionResult> Index()
    {
        var girls = await _girlRepository.GetAllGirlsAsync();
        return View(girls);
    }

    // GET: GirlController/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var girl = await _girlRepository.GetGirlAsync(id);
        girl.AvatarUrl = _configuration["Url"] + girl.AvatarUrl;
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
            var folderRelativePath = $"images/{createdGirl.Id}";
            var folderAbsolutePath = Path.Combine(webHostEnvironment.WebRootPath, folderRelativePath);
            if (!Directory.Exists(folderAbsolutePath))
            {
                Directory.CreateDirectory(folderAbsolutePath);
            }

            // var avatarFileName = Path.GetRandomFileName();
            var avatarFileName = $"{Guid.NewGuid()}_{girlCreateViewModel.Avatar.FileName}";

            var fileRelativePath = $"{folderRelativePath}/{avatarFileName}";
            var fileAbsolutePath = $"{folderAbsolutePath}/{avatarFileName}";
            using var stream = System.IO.File.Create(fileAbsolutePath);
            await girlCreateViewModel.Avatar.CopyToAsync(stream);

            createdGirl.AvatarUrl = fileRelativePath;
            await _girlRepository.UpdateGirlAsync(createdGirl);
            // updatedGirl.AvatarUrl = _configuration["Url"] + updatedGirl.AvatarUrl;
            return RedirectToAction("Details", "Girl", new { Id = createdGirl.Id });
        }
        catch
        {
            return View();
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
