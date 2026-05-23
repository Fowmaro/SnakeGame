namespace snakeGame;

public class Snake
{
    public readonly Queue<Coords> SnakePosHistory = new Queue<Coords>();

    public Coords SnakeHead { get; private set; }
    public Directions CurrentDirection { get; private set; }
    public int Length { get; private set; }

    public Snake(Coords startingPosition)
    {
        SnakeHead = startingPosition;
        CurrentDirection = Directions.Right;
        Length = 1;
        SnakePosHistory.Enqueue(SnakeHead);
    }

    public void Move(Directions inputDirection)
    {

        SnakeHead = CurrentDirection switch
        {
            Directions.Up => new Coords(SnakeHead.X, SnakeHead.Y - 1),
            Directions.Down => new Coords(SnakeHead.X, SnakeHead.Y + 1),
            Directions.Left => new Coords(SnakeHead.X - 1, SnakeHead.Y),
            Directions.Right => new Coords(SnakeHead.X + 1, SnakeHead.Y),
            _ => SnakeHead
        };

        SnakePosHistory.Enqueue(SnakeHead);

        if (SnakePosHistory.Count > Length)
        {
            SnakePosHistory.Dequeue();
        }
    }

    public void Grow()
    {
        
        Length++;
    }

    public bool HasEatenItsTale()
    {
        
        return SnakePosHistory.Count(c => c.X == SnakeHead.X && c.Y == SnakeHead.Y) > 1;
    }

    

}