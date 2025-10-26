const boardSpaces = [
    // Bottom row (right to left)
    { name: "Go", x: 720, y: 720, width: 80, height: 80, owner: null },
    { name: "Mediterranean Avenue", x: 640, y: 720, width: 80, height: 80, owner: null },
    { name: "Community Chest", x: 560, y: 720, width: 80, height: 80, owner: null },
    { name: "Baltic Avenue", x: 500, y: 720, width: 80, height: 80, owner: null },
    { name: "Income Tax", x: 450, y: 720, width: 80, height: 80, owner: null },
    { name: "Reading Railroad", x: 380, y: 720, width: 80, height: 80, owner: null },
    { name: "Oriental Avenue", x: 300, y: 720, width: 80, height: 80, owner: null },
    { name: "Chance", x: 260, y: 720, width: 80, height: 80, owner: null },
    { name: "Vermont Avenue", x: 180, y: 720, width: 80, height: 80, owner: null },
    { name: "Connecticut Avenue", x: 120, y: 720, width: 80, height: 80, owner: null },

    // Left column (bottom to top)
    { name: "Jail/Just Visiting", x: 0, y: 720, width: 80, height: 80, owner: null },
    { name: "St. Charles Place", x: 0, y: 640, width: 80, height: 80, owner: null },
    { name: "Electric Company", x: 0, y: 560, width: 80, height: 80, owner: null },
    { name: "States Avenue", x: 0, y: 500, width: 80, height: 80, owner: null },
    { name: "Virginia Avenue", x: 0, y: 450, width: 80, height: 80, owner: null },
    { name: "Pennsylvania Railroad", x: 0, y: 390, width: 80, height: 80, owner: null },
    { name: "St. James Place", x: 0, y: 320, width: 80, height: 80, owner: null },
    { name: "Community Chest", x: 0, y: 240, width: 80, height: 80, owner: null },
    { name: "Tennessee Avenue", x: 0, y: 170, width: 80, height: 80, owner: null },
    { name: "New York Avenue", x: 0, y: 100, width: 80, height: 80, owner: null },

    // Top row (left to right)
    { name: "Free Parking", x: 0, y: 0, width: 80, height: 80, owner: null },
    { name: "Kentucky Avenue", x: 120, y: 0, width: 80, height: 80, owner: null },
    { name: "Chance", x: 180, y: 0, width: 80, height: 80, owner: null },
    { name: "Indiana Avenue", x: 260, y: 0, width: 80, height: 80, owner: null },
    { name: "Illinois Avenue", x: 300, y: 0, width: 80, height: 80, owner: null },
    { name: "B&O Railroad", x: 380, y: 0, width: 80, height: 80, owner: null },
    { name: "Atlantic Avenue", x: 450, y: 0, width: 80, height: 80, owner: null },
    { name: "Ventnor Avenue", x: 500, y: 0, width: 80, height: 80, owner: null },
    { name: "Water Works", x: 560, y: 0, width: 80, height: 80, owner: null },
    { name: "Marvin Gardens", x: 640, y: 0, width: 80, height: 80, owner: null },

    // Right column (top to bottom)
    { name: "Go To Jail", x: 720, y: 0, width: 80, height: 80, owner: null },
    { name: "Pacific Avenue", x: 720, y: 100, width: 80, height: 80, owner: null },
    { name: "North Carolina Avenue", x: 720, y: 170, width: 80, height: 80, owner: null },
    { name: "Community Chest", x: 720, y: 240, width: 80, height: 80, owner: null },
    { name: "Pennsylvania Avenue", x: 720, y: 320, width: 80, height: 80, owner: null },
    { name: "Short Line", x: 720, y: 390, width: 80, height: 80, owner: null },
    { name: "Chance", x: 720, y: 450, width: 80, height: 80, owner: null },
    { name: "Park Place", x: 720, y: 500, width: 80, height: 80, owner: null },
    { name: "Luxury Tax", x: 720, y: 560, width: 80, height: 80, owner: null },
    { name: "Boardwalk", x: 720, y: 640, width: 80, height: 80, owner: null },
];