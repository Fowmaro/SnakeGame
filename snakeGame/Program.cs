using System.Text;

namespace snakeGame;

class Program
{
    static async Task Main()
    {
        /*
         * make the outer box ✔
         * make the snake's head ✔
         * make the apple in random dimension ✔
         * make the head move ✔
         * change head direction ✔
         * head eats apple ✔
         * make the tail ✔
         * make the death conditions ✔
         */
        int delayInMilli = 130;
        Random rnd = new Random();
        Directions direction = Directions.Right;
        Directions lastMovedDirection = Directions.Right;
        coordinates boxCoord = new coordinates(25, 16);
        coordinates snakePos = new coordinates(6, 8);
        coordinates apple = new coordinates(rnd.Next(1, boxCoord.X - 1), rnd.Next(1, boxCoord.Y - 1)); 
        DateTime time = DateTime.Now;
        Console.CursorVisible = false;
        StringBuilder screenBuffer = new StringBuilder();
        int score = 0;
        List<coordinates> snakePosHistory = new List<coordinates>();
        
        
        while (true)
        {
            direction = GetInputDirection(direction,lastMovedDirection);
            

            if ((DateTime.Now - time).TotalMilliseconds >= delayInMilli)
            {
                snakePosHistory.Add(new coordinates(snakePos.X, snakePos.Y));
                
                if (snakePosHistory.Count > score)
                    snakePosHistory.RemoveAt(0);
                snakePos.ChangePos(direction);
                lastMovedDirection = direction;
                
                if (snakePos.X == 0 || snakePos.Y == 0 || snakePos.X == boxCoord.X-1 || snakePos.Y == boxCoord.Y-1
                    || snakePosHistory.Any(c => c.X == snakePos.X && c.Y == snakePos.Y))
                {
                    score = 0;
                    snakePos.ChangePos(6,8);
                    snakePosHistory.Clear();
                    direction = Directions.Right;
                    apple.RandomPos(boxCoord,snakePosHistory);
                    continue;
                }
                
                
                time = DateTime.Now;
                Console.SetCursorPosition(0, 1);
                screenBuffer.Clear();
                if (snakePos.Equals(apple))
                {
                    apple.RandomPos(boxCoord,snakePosHistory);
                    score++;
                }
                for (int y = 0; y < boxCoord.Y; y++)
                {
                    for (int x = 0; x < boxCoord.X; x++)
                    {
                        if ((snakePos.X == x && snakePos.Y == y) || snakePosHistory.Any(c => c.X == x && c.Y == y))
                        {
                            screenBuffer.Append("██");
                        }
                        else if (apple.X == x && apple.Y == y)
                            screenBuffer.Append("🍏");
                        else if (x == 0 || y == 0 || x == boxCoord.X - 1 || y == boxCoord.Y - 1)
                            screenBuffer.Append("▓▓");
                        else screenBuffer.Append("  ");
                    }

                    screenBuffer.AppendLine();
                }

              
                
                screenBuffer.Append($"score: {score}");
                Console.Write(screenBuffer.ToString());
            }
            
            System.Threading.Thread.Sleep(2);
        }

    }
    static Directions GetInputDirection(Directions currentDirection, Directions lastMovedDirection)
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