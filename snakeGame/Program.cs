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
         * head eats apple
         * make the tail
         * make the death conditions
         */
        int delayInMilli = 100;
        Random rnd = new Random();
        Directions direction = Directions.Up;
        coordinates boxCoord = new coordinates(25, 15);
        coordinates snakePos = new coordinates(5, 10);
        coordinates apple = new coordinates(rnd.Next(1, boxCoord.X - 1), rnd.Next(1, boxCoord.Y - 1)); 
        DateTime time = DateTime.Now;
        Console.CursorVisible = false;
        StringBuilder screenBuffer = new StringBuilder();
        while (true)
        {
            direction = GetInputDirection(direction);
            /*if (direction == Directions.Up || direction == Directions.Down)
            {
                delayInMilli = 120;
            }
            else
            {
                delayInMilli = 60;
            }*/
            delayInMilli = 100;

            if ((DateTime.Now - time).TotalMilliseconds >= delayInMilli)
            {
                snakePos.ChangePos(direction);
                time = DateTime.Now;
                Console.SetCursorPosition(0, 1);
                screenBuffer.Clear();
                
                for (int y = 0; y < boxCoord.Y; y++)
                {
                    for (int x = 0; x < boxCoord.X; x++)
                    {
                        coordinates currentCoord = new coordinates(x, y);
                        if (snakePos.Equals(currentCoord))
                        {
                            screenBuffer.Append("██");
                        }
                        else if (apple.Equals(currentCoord))
                            screenBuffer.Append("🍏");
                        else if (x == 0 || y == 0 || x == boxCoord.X - 1 || y == boxCoord.Y - 1)
                            screenBuffer.Append("##");
                        else screenBuffer.Append("  ");
                    }

                    screenBuffer.AppendLine();
                }
                Console.Write(screenBuffer.ToString());
            }
            System.Threading.Thread.Sleep(1);
        }

    }
  static Directions GetInputDirection(Directions currentDirection)
    {
        while (Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if ((currentDirection != Directions.Down))
                        currentDirection = Directions.Up;
                    
                    break;
                case ConsoleKey.DownArrow:
                    if ((currentDirection != Directions.Up))
                        currentDirection = Directions.Down;
                    
                    break;
                case ConsoleKey.RightArrow:
                    if (currentDirection != Directions.Left)
                        currentDirection = Directions.Right;
                    break;
                case ConsoleKey.LeftArrow:
                    if (currentDirection != Directions.Right)
                        currentDirection = Directions.Left;
                    break;
            
            }
        }
        return currentDirection;
    }
}