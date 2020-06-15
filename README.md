# ConwaysGameOfLife
A simple and easy to follow implementation of Conway's Game Of Life.

The GameOfLife object handles the game and exposes one method to the programmer using it; SpawnNextGeneration().

The GoL_GraphicsManager object requires a reference to the GameOfLife object and exposes it's Draw() method. 
The Draw() method also updates the scene, usually this would be a separate method. 
Notice the "sceneBuffer" member field, the entire screen's output is written to this string before being displayed.
This way we can simply move the Console cursor to (0,0) and print to screen. Removing that nasty flicker that Console applications
normally deal with. 
