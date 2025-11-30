using MonopolyGame.Models;
using System.Collections.Generic;

namespace MonopolyGame.Util;

public static class Util
{
    public static void GenerateProperties(Game game, ApplicationDbContext context)
    { 
        // Helper for streets (houses/hotel applicable)
        void AddStreet(
            string name, string color, int price, int housePrice, int baseRent,
            int r1, int r2, int r3, int r4, int rHotel
        )
        {
            context.Properties.Add(new Property
            {
                Name = name,
                Price = price,
                BaseRent = baseRent,
                RentLvl1 = r1,
                RentLvl2 = r2,
                RentLvl3 = r3,
                RentLvl4 = r4,
                RentHotel = rHotel,
                Level = 0,
                HousePrice = housePrice,
                HotelPrice = housePrice,
                ColorGroup = color,
                GameId = game.Id,
                OwnerId = null
            });
        }

        // Helper for railroads (no houses, escalating rent by count)
        void AddRailroad(string name)
        {
            context.Properties.Add(new Property
            {
                Name = name,
                Price = 200,
                BaseRent = 25,    // 1 RR
                RentLvl1 = 50,    // 2 RRs
                RentLvl2 = 100,   // 3 RRs
                RentLvl3 = 200,   // 4 RRs
                RentLvl4 = 200,
                RentHotel = 200,
                Level = 0,
                HousePrice = 0,
                HotelPrice = 0,
                ColorGroup = "Railroad",
                GameId = game.Id,
                OwnerId = null
            });
        }

        // Helper for utilities (rent is multiplier on dice; encode multipliers in rent fields)
        void AddUtility(string name)
        {
            context.Properties.Add(new Property
            {
                Name = name,
                Price = 150,
                BaseRent = 4,     // 4x dice roll with 1 utility
                RentLvl1 = 10,    // 10x dice roll with both utilities
                RentLvl2 = 10,
                RentLvl3 = 10,
                RentLvl4 = 10,
                RentHotel = 10,
                Level = 0,
                HousePrice = 0,
                HotelPrice = 0,
                ColorGroup = "Utility",
                GameId = game.Id,
                OwnerId = null
            });
        }

        // Brown
        AddStreet("Mediterranean Avenue", "Brown", 60, 50, 2, 10, 30, 90, 160, 250);
        AddStreet("Baltic Avenue", "Brown", 60, 50, 4, 20, 60, 180, 320, 450);

        // Light Blue
        AddStreet("Oriental Avenue", "Light Blue", 100, 50, 6, 30, 90, 270, 400, 550);
        AddStreet("Vermont Avenue", "Light Blue", 100, 50, 6, 30, 90, 270, 400, 550);
        AddStreet("Connecticut Avenue", "Light Blue", 120, 50, 8, 40, 100, 300, 450, 600);

        // Pink (Magenta)
        AddStreet("St. Charles Place", "Pink", 140, 100, 10, 50, 150, 450, 625, 750);
        AddStreet("States Avenue", "Pink", 140, 100, 10, 50, 150, 450, 625, 750);
        AddStreet("Virginia Avenue", "Pink", 160, 100, 12, 60, 180, 500, 700, 900);

        // Orange
        AddStreet("St. James Place", "Orange", 180, 100, 14, 70, 200, 550, 750, 950);
        AddStreet("Tennessee Avenue", "Orange", 180, 100, 14, 70, 200, 550, 750, 950);
        AddStreet("New York Avenue", "Orange", 200, 100, 16, 80, 220, 600, 800, 1000);

        // Red
        AddStreet("Kentucky Avenue", "Red", 220, 150, 18, 90, 250, 700, 875, 1050);
        AddStreet("Indiana Avenue", "Red", 220, 150, 18, 90, 250, 700, 875, 1050);
        AddStreet("Illinois Avenue", "Red", 240, 150, 20, 100, 300, 750, 925, 1100);

        // Yellow
        AddStreet("Atlantic Avenue", "Yellow", 260, 150, 22, 110, 330, 800, 975, 1150);
        AddStreet("Ventnor Avenue", "Yellow", 260, 150, 22, 110, 330, 800, 975, 1150);
        AddStreet("Marvin Gardens", "Yellow", 280, 150, 24, 120, 360, 850, 1025, 1200);

        // Green
        AddStreet("Pacific Avenue", "Green", 300, 200, 26, 130, 390, 900, 1100, 1275);
        AddStreet("North Carolina Avenue", "Green", 300, 200, 26, 130, 390, 900, 1100, 1275);
        AddStreet("Pennsylvania Avenue", "Green", 320, 200, 28, 150, 450, 1000, 1200, 1400);

        // Dark Blue
        AddStreet("Park Place", "Dark Blue", 350, 200, 35, 175, 500, 1100, 1300, 1500);
        AddStreet("Boardwalk", "Dark Blue", 400, 200, 50, 200, 600, 1400, 1700, 2000);

        // Railroads
        AddRailroad("Reading Railroad");
        AddRailroad("Pennsylvania Railroad");
        AddRailroad("B. & O. Railroad");
        AddRailroad("Short Line");

        // Utilities
        AddUtility("Electric Company");
        AddUtility("Water Works");

        context.SaveChanges();
    }
}