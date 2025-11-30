using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MonopolyGame.Models;

namespace MonopolyGame.Areas.Api.Controllers;

[Area("Api")]
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PlayerController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    
    public PlayerController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var player = _context.Players.Find(id);
        if (player == null)
            return NotFound();
        return Ok(player);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Player updatedPlayer)
    {
        if (id != updatedPlayer.Id)
        {
            return BadRequest();
        }
        var player = _context.Players.Find(id);
        if (player == null)
            return NotFound();
        player.Name = updatedPlayer.Name;
        player.Money = updatedPlayer.Money;
        player.Space = updatedPlayer.Space;
        player.TurnNumber = updatedPlayer.TurnNumber;
        _context.SaveChanges();
        return Ok(player);
    }
}