using System;
public class PaperStrip
{
    public static int MinPieces(int[] original, int[] desired)
    {
        int count = 1, id = 0;
        for(int i = 0; i < desired.Length; i++)
        {
            if(i == (desired.Length - 1) && id < (desired.Length - 1))
            {
                if(original[id] != desired[i])
                {
                    count++;
                    return count;
                }
                else
                {
                    count += 2;
                    return count;
                }
            }
            if (original[id] == desired[i])
            {
                if (i - 1 >= 0 && id - 1 >= 0 && original[id] == desired[i] && original[id - 1] != desired[i - 1])
                {
                        count++;
                }
                id++;
                continue;
            }
        }
        return count;
    }

    public static void Main(string[] args)
    {
        int[] original = new int[] { 1, 4, 3, 2, 5, 6};
        int[] desired = new int[] { 1, 4, 3, 2, 4, 5};
        Console.WriteLine(PaperStrip.MinPieces(original, desired));
    }
}
