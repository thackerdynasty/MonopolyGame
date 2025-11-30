using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonopolyGame.Models;

public class Player
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int TurnNumber { get; set; }
    public int Money { get; set; }
    public int Space { get; set; }
    
    [ForeignKey("Game")]
    public int GameId { get; set; }
    public Game Game { get; set; }
    
    [ForeignKey("User")]
    public string UserId { get; set; }
    public User User { get; set; }
}