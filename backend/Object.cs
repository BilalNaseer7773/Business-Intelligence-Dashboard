namespace ObjectSimulation
{
    public class SimObject
    {
        public string Name { get; set; }
        public Vector Position { get; set; }
        public Vector Velocity { get; set; }
        public double Mass { get; set; }
        public bool IsStatic { get; set; }

        public SimObject(string name, Vector position, double mass, bool isStatic = false)
        {
            Name = name;
            Position = position;
            Velocity = new Vector(0, 0);
            Mass = mass;
            IsStatic = isStatic;
        }

        public void ApplyForce(Vector force)
        {
            if (!IsStatic)
            {
                Velocity += force / Mass;
            }
        }

        public void UpdatePosition(double deltaTime)
        {
            Position += Velocity * deltaTime;
        }
    }
}

