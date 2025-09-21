using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonopolyGame.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    
    public string Username { get; set; }
    public string Email { get; set; }
    
    [ForeignKey("Game")]
    public int GameId { get; set; }
    public Game Game { get; set; }
}