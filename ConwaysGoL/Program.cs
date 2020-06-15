using System.Threading;

namespace ConwaysGoL
{
    class Program
    {
        static void Main(string[] args)
        {
            GameOfLife gameOfLife = new GameOfLife(40, 90);
            GoL_GraphicsManager graphicsManager = new GoL_GraphicsManager(gameOfLife);

            while (true)
            {
                graphicsManager.Draw();
                gameOfLife.SpawnNextGeneration();
                Thread.Sleep(125);
            }
        }
    }
}
