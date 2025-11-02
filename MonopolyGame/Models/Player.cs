using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonopolyGame.Models;

public class Player
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int TurnNumber { get; set; }
    
    public int Position { get; set; }
    public int Money { get; set; }
}