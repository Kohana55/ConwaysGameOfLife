using System;

namespace ConwaysGoL
{
    public class GameOfLife
    {
        #region Properties & Fields
        public int X { get; }
        public int Y { get; }
        public int[,] CurrentGeneration { get; private set; }

        private int[,] nextGeneration;
        #endregion

        #region Constructors
        /// <summary>
        /// Default Ctor that sets the board size to 16x16
        /// </summary>
        public GameOfLife()
        {
            X = 16;
            Y = 16;
            SeedGame();
        }

        /// <summary>
        /// Ctor that accepts a custom board size
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public GameOfLife(int x, int y)
        {
            X = x;
            Y = y;
            SeedGame();
        }
        #endregion

        #region Private
        /// <summary>
        /// Seed Game with live and dead cells
        /// Whereby the live cells occupy approx. 20% of the board
        /// </summary>
        private void SeedGame()
        {
            // Initiate the current and next generation boards
            CurrentGeneration = new int[X, Y];
            nextGeneration = new int[X, Y];

            // Cycle cells using rng to set live/dead cells
            var rng = new Random();           
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    // Random Board
                    if (rng.Next(1, 101) < 70)
                        CurrentGeneration[i, j] = 0;
                    else
                        CurrentGeneration[i, j] = 1;
                }
            }
        }

        /// <summary>
        /// Transfer next generation to current generation 
        /// </summary>
        private void TransferNextGenerations()
        {
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    CurrentGeneration[i, j] = nextGeneration[i, j];
                }
            }
        }

        /// <summary>
        /// Given any cell - calculate live neighbours
        /// </summary>
        /// <param name="x">X coord of Cell</param>
        /// <param name="y">Y coord of Cell</param>
        /// <returns></returns>
        private int CalculateLiveNeighbours(int x, int y)
        {
            // Calculate live neighours
            int liveNeighbours = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (x + i < 0 || x + i >= X)   // Out of bounds
                        continue;
                    if (y + j < 0 || y + j >= Y)   // Out of bounds
                        continue;
                    if (x + i == x && y + j == y)       // Same Cell
                        continue;

                    // Add cells value to current live neighbour count
                    liveNeighbours += CurrentGeneration[x + i, y + j];
                }
            }

            return liveNeighbours;
        }
        #endregion

        #region Public
        /// <summary>
        /// Spawn the next generation
        /// </summary>
        public void SpawnNextGeneration()
        {
            for (int x = 0; x < X; x++)
            {
                for (int y = 0; y < Y; y++)
                {
                    int liveNeighbours = CalculateLiveNeighbours(x, y);

                    if (CurrentGeneration[x, y] == 1 && liveNeighbours < 2)
                        nextGeneration[x, y] = 0;

                    else if (CurrentGeneration[x, y] == 1 && liveNeighbours > 3)
                        nextGeneration[x, y] = 0;

                    else if (CurrentGeneration[x, y] == 0 && liveNeighbours == 3)
                        nextGeneration[x, y] = 1;

                    else
                        nextGeneration[x, y] = CurrentGeneration[x, y];

                }
            }

            TransferNextGenerations();
        }
        #endregion
    }
}
