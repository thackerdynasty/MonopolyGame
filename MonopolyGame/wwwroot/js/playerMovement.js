let playerPosition = 0; // Start at "Go"

// Access the C# Player model data via window.playerData
const players = window.playersData;
const game = window.gameData;
players.forEach(player => {
    console.log(`Player ${player.id}: ${player.name}, Turn: ${player.turnNumber}`);
    // You can move each piece, update UI, etc.
});

function movePlayer(spacesToMove) {
    playerPosition = (playerPosition + spacesToMove) % boardSpaces.length;
    const space = boardSpaces[playerPosition];
    const playerDiv = document.getElementById("player1");

    playerDiv.style.left = space.x + "px";
    playerDiv.style.top = space.y + "px";
}

// Example: Move 1 space when a button is clicked
document.addEventListener("DOMContentLoaded", function() {
    document.getElementById("moveBtn").addEventListener("click", function() {
        movePlayer(1); // Move 1 space
    });
});

//Dice roller
document.getElementById("rollDiceBtn").addEventListener("click", function() {
    // Roll two dice (1–6)
    const die1 = Math.floor(Math.random() * 6) + 1;
    const die2 = Math.floor(Math.random() * 6) + 1;
    const total = die1 + die2;
    let isDouble = false;
    if (die1 == die2){
        isDouble = true;
    }

    // Display results
    document.getElementById("diceResult").innerText =
        `Die 1: ${die1}, Die 2: ${die2} — Move ${total} spaces`;
    if(isDouble){
        document.getElementById("diceResult").innerText += " DOUBLES!";
    }
    //move player
    movePlayer(total);

    document.getElementById("spaceResult").innerText =
        `Player landed on the ${boardSpaces[playerPosition].name} space`;

});