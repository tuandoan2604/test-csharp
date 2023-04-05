// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System.Runtime.Serialization;

int[] original = new int[] { 1, 4, 3, 2, 5, 6};
int[] desired = new int[] { 1, 2, 5, 4, 3, 6};

Console.WriteLine(PaperStrip.MinPieces(original, desired));

public class PaperStrip
{
    public static int MinPieces(int[] original, int[] desired)
    {
        int i = 0, j = 0;
        int n = original.Length;
        int m = n;
        List<string> pieces = new List<string>();

        for (i = 0; i < n; i++)
        {
            for (j = 0; j < n; j++)
            {
                string str = "";
                if (original[i] == desired[j])
                {
                    do
                    {
                        str += original[i].ToString();
                        i++;
                        j++;
                    }
                    while ((i < n) && (j < n) && (original[i] == desired[j]));

                    i--;
                    pieces.Add(str);
                    break;
                }
                
            }
        }        
        return pieces.Count;

    }
    
    
}
