using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MonopolyGame.Models;

public class User: IdentityUser
{
    [ForeignKey("Game")]
    public int? GameId { get; set; }
    public Game? Game { get; set; }
}