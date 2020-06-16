using System.Threading;
using System.Threading.Tasks;

namespace ConwaysGoL
{
    class Program
    {
        static async Task Main()
        {
            GameOfLife gameOfLife = new GameOfLife(40, 90);
            GoL_GraphicsManager graphicsManager = new GoL_GraphicsManager(gameOfLife);

            while (true)
            {
                graphicsManager.Draw();
                gameOfLife.SpawnNextGeneration();
                await Task.Delay(125);
            }
        }
    }
}