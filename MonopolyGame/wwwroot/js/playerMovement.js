let playerPosition = 0; // Start at "Go"

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