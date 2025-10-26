using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MonopolyGame.Models;

namespace MonopolyGame.Controllers;

[Authorize]
public class GamesController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;

    public GamesController(ApplicationDbContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
    
    // GET
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return RedirectToAction("Index", "Home");
        List<Game> games = _context.Games.Where(g => g.IsJoinable && g.Id != user.GameId).ToList();
        return View(games);
    }

    public async Task<IActionResult> Join(int id)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return RedirectToAction("Index", "Home");
        var game = await _context.Games.FindAsync(id);
        if (game is not { IsJoinable: true } || user.GameId != null) return RedirectToAction("Index", "Home");
        user.GameId = id;
        game.Players += 1;
        if (game.Players >= game.MaxPlayers)
        {
            game.IsJoinable = false;
        }
        await _context.SaveChangesAsync();
        await _userManager.UpdateAsync(user);
        return RedirectToAction("MyGame");
    }

    public async Task<IActionResult> MyGame()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return RedirectToAction("Index", "Home");
        var game = _context.Games.FirstOrDefault(g => g.Id == user.GameId);
        // integrate the frontend game system here
        throw new NotImplementedException();
    }

    public async Task<IActionResult> Create()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user is not { GameId: null }) return RedirectToAction("Index");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Game game)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return RedirectToAction("Index", "Home");
        game.IsJoinable = true;
        game.Players = 1;
        _context.Games.Add(game);
        await _context.SaveChangesAsync();
        user.GameId = game.Id;
        await _userManager.UpdateAsync(user);
        return RedirectToAction("Index");
    }
}