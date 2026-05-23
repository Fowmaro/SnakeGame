namespace snakeGame;

public static class InputHandler
{
    public static Directions GetInputDirection(Directions currentDirection, Directions lastMovedDirection)
    {
        while (Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (lastMovedDirection != Directions.Down)
                        currentDirection = Directions.Up;
                    break;
                
                case ConsoleKey.DownArrow:
                    if (lastMovedDirection != Directions.Up)
                        currentDirection = Directions.Down;
                    break;
                
                case ConsoleKey.RightArrow:
                    if (lastMovedDirection != Directions.Left)
                        currentDirection = Directions.Right;
                    break;
                
                case ConsoleKey.LeftArrow:
                    if (lastMovedDirection != Directions.Right)
                        currentDirection = Directions.Left;
                    break;
            }
        }
        return currentDirection;
    }
}