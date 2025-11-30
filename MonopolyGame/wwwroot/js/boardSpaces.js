const boardSpaces = [
    // Bottom row (right to left)
    { name: "Go", x: 720, y: 720, width: 80, height: 80, owner: null, type: "event" },
    { name: "Mediterranean Avenue", x: 640, y: 720, width: 80, height: 80, owner: null, type: "property", price: 60 },
    { name: "Community Chest", x: 560, y: 720, width: 80, height: 80, owner: null, type: "event"},
    { name: "Baltic Avenue", x: 500, y: 720, width: 80, height: 80, owner: null, type: "property", price: 60 },
    { name: "Income Tax", x: 450, y: 720, width: 80, height: 80, owner: null, type: "event" },
    { name: "Reading Railroad", x: 380, y: 720, width: 80, height: 80, owner: null, type: "property", price: 200 },
    { name: "Oriental Avenue", x: 300, y: 720, width: 80, height: 80, owner: null, type: "property", price: 100 },
    { name: "Chance", x: 260, y: 720, width: 80, height: 80, owner: null, type: "event" },
    { name: "Vermont Avenue", x: 180, y: 720, width: 80, height: 80, owner: null, type: "property", price: 100 },
    { name: "Connecticut Avenue", x: 120, y: 720, width: 80, height: 80, owner: null, type: "property", price: 120 },

    // Left column (bottom to top)
    { name: "Jail/Just Visiting", x: 0, y: 720, width: 80, height: 80, owner: null, type: "none" },
    { name: "St. Charles Place", x: 0, y: 640, width: 80, height: 80, owner: null, type: "property", price: 140 },
    { name: "Electric Company", x: 0, y: 560, width: 80, height: 80, owner: null, type: "property", price: 150 },
    { name: "States Avenue", x: 0, y: 500, width: 80, height: 80, owner: null, type: "property", price: 140 },
    { name: "Virginia Avenue", x: 0, y: 450, width: 80, height: 80, owner: null, type: "property", price: 160 },
    { name: "Pennsylvania Railroad", x: 0, y: 390, width: 80, height: 80, owner: null, type: "property", price: 200 },
    { name: "St. James Place", x: 0, y: 320, width: 80, height: 80, owner: null, type: "property", price: 180 },
    { name: "Community Chest", x: 0, y: 240, width: 80, height: 80, owner: null, type: "event" },
    { name: "Tennessee Avenue", x: 0, y: 170, width: 80, height: 80, owner: null, type: "property", price: 180 },
    { name: "New York Avenue", x: 0, y: 100, width: 80, height: 80, owner: null, type: "property", price: 200 },

    // Top row (left to right)
    { name: "Free Parking", x: 0, y: 0, width: 80, height: 80, owner: null, type: "none" },
    { name: "Kentucky Avenue", x: 120, y: 0, width: 80, height: 80, owner: null, type: "property", price: 220 },
    { name: "Chance", x: 180, y: 0, width: 80, height: 80, owner: null, type: "event" },
    { name: "Indiana Avenue", x: 260, y: 0, width: 80, height: 80, owner: null, type: "property", price: 220 },
    { name: "Illinois Avenue", x: 300, y: 0, width: 80, height: 80, owner: null, type: "property", price: 240 },
    { name: "B&O Railroad", x: 380, y: 0, width: 80, height: 80, owner: null, type: "property", price: 200 },
    { name: "Atlantic Avenue", x: 450, y: 0, width: 80, height: 80, owner: null, type: "property", price: 260 },
    { name: "Ventnor Avenue", x: 500, y: 0, width: 80, height: 80, owner: null, type: "property", price: 260 },
    { name: "Water Works", x: 560, y: 0, width: 80, height: 80, owner: null, type: "property", price: 150 },
    { name: "Marvin Gardens", x: 640, y: 0, width: 80, height: 80, owner: null, type: "property", price: 260 },

    // Right column (top to bottom)
    { name: "Go To Jail", x: 720, y: 0, width: 80, height: 80, owner: null, type: "event" },
    { name: "Pacific Avenue", x: 720, y: 100, width: 80, height: 80, owner: null, type: "property", price: 300 },
    { name: "North Carolina Avenue", x: 720, y: 170, width: 80, height: 80, owner: null, type: "property", price: 300 },
    { name: "Community Chest", x: 720, y: 240, width: 80, height: 80, owner: null, type: "event" },
    { name: "Pennsylvania Avenue", x: 720, y: 320, width: 80, height: 80, owner: null, type: "property", price: 320 },
    { name: "Short Line", x: 720, y: 390, width: 80, height: 80, owner: null, type: "property", price: 200 },
    { name: "Chance", x: 720, y: 450, width: 80, height: 80, owner: null, type: "event" },
    { name: "Park Place", x: 720, y: 500, width: 80, height: 80, owner: null, type: "property", price: 350 },
    { name: "Luxury Tax", x: 720, y: 560, width: 80, height: 80, owner: null, type: "event" },
    { name: "Boardwalk", x: 720, y: 640, width: 80, height: 80, owner: null, type: "property", price: 400 },
];