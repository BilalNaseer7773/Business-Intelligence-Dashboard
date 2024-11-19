using System;

namespace ObjectSimulation
{
    public static class CollisionHandler
    {
        public static void HandleCollision(SimObject a, SimObject b)
        {
            double distance = (a.Position - b.Position).Magnitude();
            if (distance < 1.0) // Assuming objects have a radius of 0.5 units
            {
                // Elastic collision logic
                Vector normal = (a.Position - b.Position) / distance;
                Vector relativeVelocity = a.Velocity - b.Velocity;

                double velocityAlongNormal = Vector.Dot(relativeVelocity, normal);
                if (velocityAlongNormal > 0) return;

                double restitution = 0.9; // Bounciness factor
                double impulseMagnitude = -(1 + restitution) * velocityAlongNormal / (1 / a.Mass + 1 / b.Mass);

                Vector impulse = normal * impulseMagnitude;
                a.Velocity += impulse / a.Mass;
                b.Velocity -= impulse / b.Mass;
            }
        }
    }
}

