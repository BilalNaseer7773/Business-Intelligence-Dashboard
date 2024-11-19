using System;
using System.Collections.Generic;

namespace ObjectSimulation
{
    public class SimulationEngine
    {
        public List<SimObject> Objects { get; private set; } = new List<SimObject>();
        private const double Gravity = 9.8;
        private const double Friction = 0.01;

        public void AddObject(SimObject obj)
        {
            Objects.Add(obj);
        }

        public void Update(double deltaTime)
        {
            foreach (var obj in Objects)
            {
                if (!obj.IsStatic)
                {
                    obj.ApplyForce(new Vector(0, -obj.Mass * Gravity));
                    obj.Velocity *= (1 - Friction);
                    obj.UpdatePosition(deltaTime);
                }
            }
            HandleCollisions();
        }

        private void HandleCollisions()
        {
            for (int i = 0; i < Objects.Count; i++)
            {
                for (int j = i + 1; j < Objects.Count; j++)
                {
                    CollisionHandler.HandleCollision(Objects[i], Objects[j]);
                }
            }
        }
    }
}

