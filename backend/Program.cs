using System;

namespace ObjectSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new SimulationEngine();

            engine.AddObject(new SimObject("Ball1", new Vector(0, 10), 2.0));
            engine.AddObject(new SimObject("Ball2", new Vector(0, 5), 3.0));

            double deltaTime = 0.016; // 60 FPS

            while (true)
            {
                Console.Clear();
                engine.Update(deltaTime);
                foreach (var obj in engine.Objects)
                {
                    Console.WriteLine($"{obj.Name}: Position({obj.Position.X}, {obj.Position.Y})");
                }
                System.Threading.Thread.Sleep(16); // Simulate 60 FPS
            }
        }
    }
}

