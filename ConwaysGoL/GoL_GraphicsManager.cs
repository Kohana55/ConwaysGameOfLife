using System;

namespace ConwaysGoL
{
    class GoL_GraphicsManager
    {
        #region Fields
        private string sceneBuffer = "";
        private GameOfLife m_gol;
        #endregion

        #region Ctors
        /// <summary>
        /// Standard Ctor
        /// </summary>
        /// <param name="gol">Game of Life object to be rendered</param>
        public GoL_GraphicsManager(GameOfLife gol)
        {
            m_gol = gol;
            Console.CursorVisible = false;
            Console.SetWindowSize(100, 45);
        }
        #endregion

        #region Public
        /// <summary>
        /// Updates the scene and draws it
        /// </summary>
        public void Draw()
        {
            // Update Scene
            sceneBuffer = "";
            for (int i = 0; i < m_gol.X; i++)
            {
                for (int j =0; j<m_gol.Y; j++)
                {
                    if (m_gol.CurrentGeneration[i, j] == 1)
                        sceneBuffer += ".";
                    else
                        sceneBuffer += " ";
                }
                sceneBuffer += "\n";
            }

            // Draw Scene
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(sceneBuffer);
        }
        #endregion
    }
}
