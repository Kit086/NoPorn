using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NoPorn.Mvc.Models;
using NoPorn.Mvc.Repositories;

namespace NoPorn.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IGirlRepository _girlRepository;

    public HomeController(ILogger<HomeController> logger, IGirlRepository girlRepository)
    {
        _logger = logger;
        _girlRepository = girlRepository;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public async Task<IActionResult> PickOne()
    {
        // TODO: 随机获取一个人，然后从剩余的人里再随机获取一个
        var girlCount = await _girlRepository.CountAsync();
        if (girlCount <= 1)
        {
            throw new Exception("数据库里Girls少于2个，无法进行比较");
        }
        var random = new Random();
        var firstGirlId = random.Next(1, girlCount);
        var secondGirlId = random.Next(1, girlCount);
        while (secondGirlId == firstGirlId)
        {
            secondGirlId = random.Next(1, girlCount);
        }
        var firstGirl = await _girlRepository.GetGirlAsync(firstGirlId);
        var secondGirl = await _girlRepository.GetGirlAsync(secondGirlId);
        var pickOneViewModel = new PickOneViewModel { FirstGirl = firstGirl, SecondGirl = secondGirl };
        var jsonResult = JsonConvert.SerializeObject(pickOneViewModel, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        return View("PickOne", jsonResult);
    }
}
