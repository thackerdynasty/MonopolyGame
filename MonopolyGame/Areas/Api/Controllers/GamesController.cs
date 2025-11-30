using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MonopolyGame.Models;

namespace MonopolyGame.Areas.Api.Controllers;

[Area("Api")]
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class GamesController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    
    public GamesController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var game = _context.Games.Find(id);
        if (game == null)
        {
            return NotFound();
        }
        return Ok(game);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Game updatedGame)
    {
        if (id != updatedGame.Id)
        {
            return BadRequest();
        }
        var game = _context.Games.Find(id);
        if (game == null)
            return NotFound();
        game.Name = updatedGame.Name;
        game.Players = updatedGame.Players;
        game.IsJoinable = updatedGame.IsJoinable;
        game.MaxPlayers = updatedGame.MaxPlayers;
        _context.SaveChanges();
        return Ok(game);
    }
}