using System.Text;

namespace snakeGame;

class Program
{
    static async Task Main()
    {
        int width = 25;
        int height = 16;
      int delayInMilli = 130;

      Engine engine = new Engine(width, height);
      Render renderer = new Render();

      Directions currentInput = Directions.Right;

      while (true)
      {
          currentInput = InputHandler.GetInputDirection(currentInput,);

          engine.Update(currentInput);

          renderer.Draw(engine);

          if (engine.IsGameOver)
          {
              Console.WriteLine("Press ENTER to restart...");
      
              while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
      
              engine.Reset();
              currentInput = Directions.Right;
          }

          await Task.Delay(delayInMilli);
      }
      
    }


}