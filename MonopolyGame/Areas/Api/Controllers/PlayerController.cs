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
    
    [HttpPost("SaveAll")]
    public IActionResult SaveAll([FromBody] List<Player> players)
    {
        foreach (var updatedPlayer in players)
        {
            var player = _context.Players.Find(updatedPlayer.Id);
            if (player != null)
            {
                _context.Entry(player).CurrentValues.SetValues(updatedPlayer);
            }
            else
            {
                return BadRequest();
            }
        }
        _context.SaveChanges();
        return Ok();
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
        _context.Entry(player).CurrentValues.SetValues(updatedPlayer);
        _context.SaveChanges();
        return Ok(player);
    }
}