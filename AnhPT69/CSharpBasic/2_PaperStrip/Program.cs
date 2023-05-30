using System;
public class PaperStrip
{
    public static int MinPieces(int[] original, int[] desired)
    {
        int n = original.Length;
        int[] next_position = new int[n + 1];
        int pieces = 0;

        for (int i = 0; i < n - 1; i++) 
        {              
            int index = original[i];
            next_position[index] = original[i + 1];

        }

        for (int j = 0; j < n; j++) 
        {
            if (j == n - 1)
            {
                pieces++;
                break;
            }    
            int index = desired[j];
            if (next_position[index] == desired[j + 1])
            {
                continue;
            }
            pieces++;
        }

        return pieces;
        
    }

    public static void Main(string[] args)
    {
        int[] original = new int[] { 5, 6, 1, 4, 3, 2 };
        int[] desired = new int[] { 1, 4,3,2, 5,6 };
        Console.WriteLine(PaperStrip.MinPieces(original, desired));
    }
}

