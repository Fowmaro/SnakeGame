namespace snakeGame;

public class Engine
{
    public Snake Snake { get; set; }
    public Coords ApplePos { get; set; }
    public int MaxX { get; set; }
    public int MaxY { get; set; }
    public int Score { get; set; }
    public bool IsGameOver { get; private set; }
    
    public event Action OnAppleEaten;
    public event Action OnGameOver;
    
    private readonly Random _random = new Random();
    
    public Engine(int width, int height)
    {
        MaxX = width;
        MaxY = height;
        Reset();
    }
    public void Update(Directions currentInput)
    {
        
        Snake.Move(currentInput);

        if (CheckWallCollision() || Snake.HasEatenItsTale())
        {
            IsGameOver = true;
            OnGameOver?.Invoke(); 
            return;
        }

       
        if (Snake.SnakeHead.Equals(ApplePos))
        {
            Snake.Grow();
            Score++;
            SpawnApple();
            OnAppleEaten?.Invoke();
        }
    }
    
    //done
    public void Reset()
    {
        Snake = new Snake(new Coords(MaxX / 2, MaxY / 2));
        Score = 0;
        IsGameOver = false;
        SpawnApple();
    }

    // Done!
    private void SpawnApple()
    {
        Coords newApplePos;
        
        do
        {
            newApplePos = new Coords(
                _random.Next(1, MaxX - 1),
                _random.Next(1, MaxY - 1)
            );
        } 
        while (Snake.SnakePosHistory.Contains(newApplePos));
        
        ApplePos = newApplePos;
    }
    
    // Done!
    private bool CheckWallCollision()
    {
        var head = Snake.SnakeHead;
        return head.X <= 0 || head.X >= MaxX - 1 || 
               head.Y <= 0 || head.Y >= MaxY - 1;
    }
}