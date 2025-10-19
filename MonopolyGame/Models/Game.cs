using System.ComponentModel.DataAnnotations;

namespace MonopolyGame.Models;

public class Game
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public int Players { get; set; }
    
    [Required]
    public bool IsJoinable { get; set; }
}