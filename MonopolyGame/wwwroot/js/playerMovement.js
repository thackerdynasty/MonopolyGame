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
    
    // Display player's money values
    updateMoneyTotals();
    
    document.getElementById("turnMessage").textContent =
        `${player.name}'s turn! Click the button to roll the dice.`;
    document.getElementById("rollDiceBtn").disabled = false; // Enable button for new player
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
    
    if (space.owner == null){
        //TODO: make property object and get the buy property values to show up
        showBuyPropertyCard(null, player);
    }
}

function updateMoneyTotals() {
    const list = document.getElementById('moneyTotals');
    if (!list) return;
    list.innerHTML = ''; // Clear old list
    window.playersData.forEach(p => {
        const li = document.createElement('li');
        li.textContent = `${p.name}: $${p.money}`;
        list.appendChild(li);
    });
}

// Call this when a player lands on an available property
function showBuyPropertyCard(property, player) {
    // Fill in content
    document.getElementById('buyPropertyInfo').innerHTML =
        `<strong>${player.name}</strong> landed on <strong>property</strong>!<br>
        Price: <span style="color:green;">$100</span><br>
        Do you want to buy this property?`;
        //`<strong>${player.name}</strong> landed on <strong>${property.name}</strong>!<br>
         //Price: <span style="color:green;">$${property.price}</span><br>
         //Do you want to buy this property?`;
    // Show modal
    document.getElementById('buyPropertyCard').style.display = 'block';
}

// Hide the buy property card
function hideBuyPropertyCard() {
    document.getElementById('buyPropertyCard').style.display = 'none';
}

document.getElementById('buyPropertyBtn').addEventListener('click', function() {
    // Take payment, give property, update money, etc.
    // Call your game logic here!
    // For demo, just hide card.
    hideBuyPropertyCard();
    alert("Property purchased! (Add your own logic here.)");
    // Also: You probably want to call updateMoneyTotals() and refresh any ownership visuals.
});

document.getElementById('skipPropertyBtn').addEventListener('click', function() {
    hideBuyPropertyCard();
    // Your code to continue the turn (e.g., next player or auction)
});

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

    // Disable the button so it can’t be clicked again this turn
    document.getElementById("rollDiceBtn").disabled = true;
    
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