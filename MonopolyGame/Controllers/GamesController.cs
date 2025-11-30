using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MonopolyGame.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

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
        if (user.GameId != null) return RedirectToAction("Index", "Home");

        await using var tx = await _context.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        try
        {
            // 1) Atomic capacity check + increment to avoid race conditions
            var rows = await _context.Database.ExecuteSqlRawAsync(
                @"UPDATE [Games]
                  SET [Players] = [Players] + 1,
                      [IsJoinable] = CASE WHEN [Players] + 1 >= [MaxPlayers] THEN CAST(0 AS bit) ELSE [IsJoinable] END
                  WHERE [Id] = {0} AND [IsJoinable] = 1 AND [Players] < [MaxPlayers];",
                id);

            if (rows == 0)
            {
                await tx.RollbackAsync();
                // Game is full or not joinable anymore
                return RedirectToAction("Index", "Home");
            }

            // 2) Assign the user to the game only if they aren't already in a game
            var userRows = await _context.Database.ExecuteSqlInterpolatedAsync(
                $"UPDATE [AspNetUsers] SET [GameId] = {id} WHERE [Id] = {user.Id} AND [GameId] IS NULL;");

            if (userRows == 0)
            {
                // User got assigned to a different game concurrently; revert game increment and roll back
                await _context.Database.ExecuteSqlRawAsync(
                    @"UPDATE [Games]
                      SET [Players] = [Players] - 1,
                          [IsJoinable] = CASE WHEN [Players] - 1 < [MaxPlayers] THEN CAST(1 AS bit) ELSE [IsJoinable] END
                      WHERE [Id] = {0};",
                    id);

                await tx.RollbackAsync();
                return RedirectToAction("Index", "Home");
            }

            // Keep in-memory object in sync (optional)
            user.GameId = id;
            
            // 3) Create player object and commit to db
            var player = new Player
            {
                UserId = user.Id,
                TurnNumber = 0,
                Money = 1500,
                Space = 0,
                GameId = id,
                Name = user.UserName
            };
            _context.Players.Add(player);

            await tx.CommitAsync();
            await _context.SaveChangesAsync();
            await _userManager.UpdateAsync(user);
            return RedirectToAction("MyGame");
        }
        catch
        {
            await tx.RollbackAsync();
            return RedirectToAction("Index", "Home");
        }
    }

    public async Task<IActionResult> MyGame()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return RedirectToAction("Index", "Home");
        var game = _context.Games.FirstOrDefault(g => g.Id == user.GameId);
        // integrate the frontend game system here
        return View(game);
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
        game.Players = 1;
        game.IsJoinable = game.Players < game.MaxPlayers;
        _context.Games.Add(game);
        await _context.SaveChangesAsync();
        user.GameId = game.Id;
        await _userManager.UpdateAsync(user);
        var player = new Player
        {
            UserId = user.Id,
            TurnNumber = 0,
            Money = 1500,
            Space = 0,
            GameId = game.Id,
            Name = user.UserName
        };
        _context.Players.Add(player);
        await _context.SaveChangesAsync();
        Util.Util.GenerateProperties(game, _context);
        return RedirectToAction("Index");
    }
}