using System;

namespace PhysicsSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Simulation parameters
            double mass = 2.0; // kg
            double initialVelocity = 5.0; // m/s
            double gravity = 9.8; // m/s^2
            double timeStep = 0.1; // seconds
            double position = 0.0; // Initial position
            double velocity = initialVelocity;

            Console.WriteLine("Time\tPosition\tVelocity");
            for (double time = 0; time <= 10; time += timeStep)
            {
                // Update position and velocity
                position += velocity * timeStep;
                velocity += -gravity * timeStep;

                // Collision detection with ground
                if (position < 0)
                {
                    position = 0;
                    velocity = -velocity * 0.8; // Apply a bounce with 80% energy
                }

                Console.WriteLine($"{time:F1}\t{position:F2}\t{velocity:F2}");
            }
        }
    }
}

