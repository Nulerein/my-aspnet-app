using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using my_aspnet_app.Models;

namespace my_aspnet_app.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult About()
    {
        ViewData["Message"] = "Добро пожаловать на страницу о Counter-Strike! Здесь вы найдете информацию о нашей команде и истории игры.";
        return View();
    }

    public IActionResult Contact()
    {
        ViewData["Message"] = "Свяжитесь с нами, чтобы узнать больше о Counter-Strike или присоединиться к нашему сообществу!";
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
