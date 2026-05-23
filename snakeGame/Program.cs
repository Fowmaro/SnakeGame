using System.Text;

namespace snakeGame;

class Program
{
    static async Task Main()
    {


        int width = 25;
      int height = 16;
      int delayInMilli = 130;

      // 1. Instantiate our separated components
      Engine engine = new Engine(width, height);
      Render renderer = new Render();

      Directions currentInput = Directions.Right;

      // 2. The main Game Loop
      while (true)
      {
          // A. Get Input
          currentInput = InputHandler.GetInputDirection(currentInput);

          // B. Update Game State
          engine.Update(currentInput);

          // C. Draw Game State
          renderer.Draw(engine);

          // D. Handle Game Over state
          if (engine.IsGameOver)
          {
              Console.WriteLine("Press ENTER to restart...");
      
              // Block until the user presses Enter
              while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
      
              // Reset the board and directions
              engine.Reset();
              currentInput = Directions.Right;
          }

          await Task.Delay(delayInMilli);
      }
      
    }


}