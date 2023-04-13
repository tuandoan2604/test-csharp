using System;
using System.Collections.Generic;
using System.Linq;
public class Platformer
{
    public List<int> dataPosition ;
    public int id { get; set; }
    public int length { get; set; }
    public int[] index {get; set; }
    public int position { get; set; }   
    public Platformer(int numberOfTiles, int position)
    {
        dataPosition = new List<int>();
        length = numberOfTiles;
        index = new int[numberOfTiles];
        for(int i = 0; i < numberOfTiles; i++)
        {
            index[i] = i;
        }
        this.position = position;
        id = position;
    }
    public void JumpLeft()
    {
        if(id - 2 >= 0)
        {
            this.id = Array.FindIndex<int>(index, n => n == position);
            index[id] = -1;
            length--;
            id = id - 2;
            position = index[id];
            dataPosition.Clear();
            for(int i = 0; i <= length; i++)
            {
                if (index[i] != -1)
                {
                    dataPosition.Add(index[i]);
                }
            }
            index = new int[length];
            for(int i = 0; i < length; i++)
            {
                index[i] = dataPosition[i];
            }
            
        }
    }

    public void JumpRight()
    {
        if (id + 2 < length)
        {
            this.id = Array.FindIndex<int>(index, n => n == position);
            index[id] = -1;
            length--;
            id = id + 2;
            position = index[id];
            dataPosition.Clear();
            for (int i = 0; i <= length; i++)
            {
                if (index[i] != -1)
                {
                    dataPosition.Add(index[i]);
                }
            }
            index = new int[length];
            for (int i = 0; i < length; i++)
            {
                index[i] = dataPosition[i];
            }

        }
    }

    public int Position()
    {
        return position;
    }

    public static void Main(string[] args)
    {
        Platformer platformer = new Platformer(6, 3);

        platformer.JumpLeft();
        platformer.JumpLeft();
        platformer.JumpLeft();
        platformer.JumpLeft();
        platformer.JumpRight();
        platformer.JumpRight();
        Console.WriteLine(platformer.Position());
    }
}
