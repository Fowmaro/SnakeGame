using System.Text;

namespace snakeGame;

public class Render
{
    private readonly StringBuilder _screenBuffer = new StringBuilder();
    public Render()
    {
        Console.CursorVisible = false;
    }
    
    public void Draw(Engine engine)
    {
        Console.SetCursorPosition(0, 1);
        _screenBuffer.Clear();

        var snake = engine.Snake.SnakePosHistory;
        var apple = engine.ApplePos;
       
            for (int y = 0; y < engine.MaxY; y++)
            {
                for (int x = 0; x < engine.MaxX; x++)
                {
                    if (x == 0 || y == 0 || x == engine.MaxX - 1 || y == engine.MaxY - 1)
                    {
                        _screenBuffer.Append("▓▓"); // Wall
                    }
                    else if (apple.X == x && apple.Y == y)
                    {
                        _screenBuffer.Append("🍏");
                    }
                    else if (snake.Any(c => c.X == x && c.Y == y))
                    {
                        _screenBuffer.Append("██");
                    }
                    else
                    {
                        _screenBuffer.Append("  ");
                    }
                }
                _screenBuffer.AppendLine();
            }

            _screenBuffer.AppendLine($"Score: {engine.Score}");
            Console.Write(_screenBuffer.ToString());
    }
}