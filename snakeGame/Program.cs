
namespace snakeGame;

class Program
{
    static async Task Main()
    {
        int width = 25;
        int height = 16;
      int delayInMilli = 100;

      Engine engine = new Engine(width, height);
      Render renderer = new Render();
      
      engine.OnAppleEaten += () => 
      {
          Console.Write("\a"); 
      };

      engine.OnGameOver += () => 
      {
          Console.Write("\a\a\a");
      };

      Directions currentInput = Directions.Right;

      while (true)
      {
          currentInput = InputHandler.GetInputDirection(currentInput);

          engine.Update(currentInput);

          if (engine.IsGameOver)
          {
              Console.WriteLine("Press ENTER to restart...");
      
              while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
      
              engine.Reset();
              currentInput = Directions.Right;
              Console.Clear();
          }
          renderer.Draw(engine);


          await Task.Delay(delayInMilli);
      }
      
    }


}