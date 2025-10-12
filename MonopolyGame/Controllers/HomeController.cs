using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MonopolyGame.Models;

namespace MonopolyGame.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var players = new List<Player>
        {
            new Player { Id = 1, TurnNumber = 1, Name = "Alice", Money = 200},
            new Player { Id = 2, TurnNumber = 2, Name = "Bob", Money = 200}
            // Add more players as needed
        };
        return View(players); // Pass list as model
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
}