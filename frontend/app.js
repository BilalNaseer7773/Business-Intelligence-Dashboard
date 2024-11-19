const canvas = document.getElementById('simulationCanvas');
const ctx = canvas.getContext('2d');
canvas.width = 800;
canvas.height = 400;

let objects = [];

document.getElementById('addObject').addEventListener('click', () => {
    const mass = parseFloat(document.getElementById('mass').value);
    const velocity = parseFloat(document.getElementById('velocity').value);
    objects.push({ x: Math.random() * canvas.width, y: 50, mass, velocity });
});

function update() {
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    objects.forEach(obj => {
        obj.y += obj.velocity;
        if (obj.y + 10 > canvas.height) obj.velocity *= -0.9; // Bounce
        else obj.velocity += 0.5; // Gravity
        ctx.beginPath();
        ctx.arc(obj.x, obj.y, 10, 0, Math.PI * 2);
        ctx.fill();
    });
    requestAnimationFrame(update);
}

update();

