using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonopolyGame.Models;

public class Property
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    public int Price { get; set; }
    
    public int BaseRent { get; set; }
    public int RentLvl1 { get; set; }
    public int RentLvl2 { get; set; }
    public int RentLvl3 { get; set; }
    public int RentLvl4 { get; set; }
    public int RentHotel { get; set; }
    
    public int Level { get; set; }
    
    public int HousePrice { get; set; }
    public int HotelPrice { get; set; }
    
    public string ColorGroup { get; set; }
    
    [ForeignKey("Game")]
    public int GameId { get; set; }
    public Game Game { get; set; }
    
    [ForeignKey("Player")]
    public int? OwnerId { get; set; }
    public Player? Owner { get; set; }
}