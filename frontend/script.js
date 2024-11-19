const canvas = document.getElementById("simulationCanvas");
const ctx = canvas.getContext("2d");

// Simulation parameters
let gravity = 9.8;
let mass = 2;
let velocity = 5;
let positionY = canvas.height - 20;
let timeStep = 0.05; // seconds
let isRunning = false;

// Initialize the ball
let ball = {
    x: canvas.width / 2,
    y: positionY,
    radius: 20,
    color: "blue",
    velocityY: velocity,
};

function drawBall() {
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    ctx.beginPath();
    ctx.arc(ball.x, ball.y, ball.radius, 0, Math.PI * 2);
    ctx.fillStyle = ball.color;
    ctx.fill();
    ctx.closePath();
}

function updateBall() {
    if (!isRunning) return;

    // Update position and velocity
    ball.velocityY += gravity * timeStep;
    ball.y += ball.velocityY;

    // Collision detection with ground
    if (ball.y + ball.radius > canvas.height) {
        ball.y = canvas.height - ball.radius;
        ball.velocityY = -ball.velocityY * 0.8; // Apply a bounce with 80% energy
    }
}

function simulationLoop() {
    updateBall();
    drawBall();
    if (isRunning) {
        requestAnimationFrame(simulationLoop);
    }
}

document.getElementById("startButton").addEventListener("click", () => {
    // Get user input
    mass = parseFloat(document.getElementById("mass").value);
    velocity = parseFloat(document.getElementById("velocity").value);
    ball.velocityY = velocity;
    isRunning = true;
    simulationLoop();
});
