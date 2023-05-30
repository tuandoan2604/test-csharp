// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

Platformer platformer = new Platformer(10, 4);
Console.WriteLine(platformer.Position()); // should print 3
platformer.PrintBoard();
string str = "";


while (true)
{
    
    Console.WriteLine("Left (l) or Right (r): ");
    str = Console.ReadLine();

    if (str == "l")
    {
        platformer.JumpLeft();
        Console.WriteLine(platformer.Position()); // should print 1
        platformer.PrintBoard();
    }
    else if (str == "r") 
    {
        platformer.JumpRight();
        Console.WriteLine(platformer.Position()); // should print 4
        platformer.PrintBoard();
    }
    else 
    {
        Console.WriteLine("Wrong, please input again! ");
    }
}


public class Platformer
{
    private List<int> Board = new List<int> { };
    private int NowPos;
    public Platformer(int numberOfTiles, int position)
    {
        for (int i = 0; i < numberOfTiles; i++) 
        {
            Board.Add(i);
        }

        NowPos = position;
        //throw new InvalidOperationException("Waiting to be implemented.");
    }

    public void JumpLeft()
    {
        if (NowPos != 0) 
        {
            Board.RemoveAt(NowPos);

            NowPos = (NowPos - 2 < 0) ? 0 : NowPos - 2;
        }
        //throw new InvalidOperationException("Waiting to be implemented.");
    }

    public void JumpRight()
    {
        if (NowPos != Board.Count - 1) 
        {
            Board.RemoveAt(NowPos);

            NowPos = (NowPos + 1 > Board.Count - 1) ? Board.Count - 1 : NowPos + 1;
        }
        
        //throw new InvalidOperationException("Waiting to be implemented.");
    }

    public int Position()
    {
            return Board[NowPos];
        
        //throw new InvalidOperationException("Waiting to be implemented.");
    }

    public void PrintBoard()
    {
        int n = Board.Count;

        for (int i = 0;i < n ;i++) 
        {
            if (i == NowPos) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(Board[i] + " ");
                Console.ResetColor();
            }
            else
            {
                Console.Write(Board[i] + " ");
            }    
        }
        Console.WriteLine();
    }
}