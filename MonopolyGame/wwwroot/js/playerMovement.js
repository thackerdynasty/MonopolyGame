let currentPlayerIndex = 0;

// Access the C# Player model data via window.playerData
const players = window.playersData;
//console.log("playersData in JS:", window.playersData);
players.forEach(player => {
    console.log(`Player ${player.id}: ${player.name}, Turn: ${player.turnNumber}`);
    // You can move each piece, update UI, etc.
});

// When page loads, show first player's turn
showTurnMessage();

function showTurnMessage() {
    const player = players[currentPlayerIndex];
    //console.log("players:", players);
    //console.log("currentPlayerIndex:", currentPlayerIndex);
    document.getElementById("turnMessage").textContent =
        `${player.name}'s turn! Click the button to roll the dice.`;
    
}

function nextTurn() {
    currentPlayerIndex = (currentPlayerIndex + 1) % players.length;
    showTurnMessage();
}


function movePlayer(spacesToMove) {
    const player = players[currentPlayerIndex];
    player.position = (player.position + spacesToMove) % boardSpaces.length;
    const space = boardSpaces[player.position];
    const tokenNum = currentPlayerIndex + 1;
    const playerDiv = document.getElementById("player" + tokenNum + "");
    console.log("token num: " + tokenNum);
    console.log("player" + tokenNum);
    
    playerDiv.style.left = space.x + "px";
    playerDiv.style.top = space.y + "px";
}


//Dice roller
document.getElementById("rollDiceBtn").addEventListener("click", function() {
    // Roll two dice (1–6)
    const player = players[currentPlayerIndex];
    const die1 = Math.floor(Math.random() * 6) + 1;
    const die2 = Math.floor(Math.random() * 6) + 1;
    const total = die1 + die2;
    let isDouble = false;
    if (die1 == die2){
        isDouble = true;
    }
    
    document.getElementById("turnMessage").textContent =
        `${player.name} rolled the dice!`;

    setTimeout(nextTurn, 3000); // Wait 2 seconds, then move to next player's turn

    // Display results
    document.getElementById("diceResult").innerText =
        `Die 1: ${die1}, Die 2: ${die2} — Move ${total} spaces`;
    if(isDouble){
        document.getElementById("diceResult").innerText += " DOUBLES!";
    }
    //move player
    movePlayer(total);

    document.getElementById("spaceResult").innerText =
        `${player.name} landed on the ${boardSpaces[player.position].name} space`;

});