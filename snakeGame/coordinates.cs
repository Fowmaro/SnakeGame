namespace snakeGame;

public class coordinates
{
    private int y { get; set; }
    private int x { get; set; }

    public int X
    {
        get { return x; }
    }

    public int Y
    {
        get { return y; }
    }

    public coordinates(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public bool Equals(coordinates snakePos)
    {
        return snakePos.X == this.x && snakePos.Y == this.y;
    }
    
    public void ChangePos(Directions direction)
    {
        switch (direction)
        {
            case Directions.Down:
                this.y++;
                break;
            case Directions.Up:
                this.y--;
                break;
            case Directions.Left:
                this.x--;
                break;
            case Directions.Right:
                this.x++;
                break;
        }
    }
    

}