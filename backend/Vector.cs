using System;

namespace ObjectSimulation
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Vector operator +(Vector a, Vector b) => new Vector(a.X + b.X, a.Y + b.Y);
        public static Vector operator -(Vector a, Vector b) => new Vector(a.X - b.X, a.Y - b.Y);
        public static Vector operator *(Vector a, double scalar) => new Vector(a.X * scalar, a.Y * scalar);
        public static Vector operator /(Vector a, double scalar) => new Vector(a.X / scalar, a.Y / scalar);

        public double Magnitude() => Math.Sqrt(X * X + Y * Y);
    }
}

