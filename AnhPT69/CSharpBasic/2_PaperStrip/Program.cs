using System;
public class PaperStrip
{
    public static int MinPieces(int[] original, int[] desired)
    {
        int i = 0;
        int n = original.Length;
        int pieces = 0;
        int[] pos = Enumerable.Repeat(-1, n).ToArray();

        for (i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (pos[j] == -1)
                {
                    if (original[i] == desired[j])
                    {
                        do
                        {
                            pos[j] = 1;
                            i++;
                            j++;
                        }
                        while ((i < n) && (j < n) && (original[i] == desired[j]));

                        i--;
                        pieces++;
                        break;
                    }
                }

            }
        }
        return pieces;
    }

    public static void Main(string[] args)
    {
        int[] original = new int[] { 1, 4, 3, 2, 5, 6 };
        int[] desired = new int[] { 1, 2, 5, 4, 3, 6 };
        Console.WriteLine(PaperStrip.MinPieces(original, desired));
    }
}

