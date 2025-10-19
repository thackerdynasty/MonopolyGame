using Microsoft.AspNetCore.Mvc;

namespace MonopolyGame.Controllers;

public class GamesController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}