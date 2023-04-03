// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

int[] str = new int[] { 1, 3, 1, -1, 3 };
Console.WriteLine("Result: " + InternalNodes.Count(str));
Console.ReadLine();



public class InternalNodes
{
    public static int Count(params int[] tree)
    {
        int n = tree.Length;
        bool oke;
        int j = 0;
        List<int> Nodes = new List<int>();

        for (int i = 0; i < n; i++) 
        {
            oke = false;
            j = 0;
            while ((j < n) && (oke == false))
            {
                if (i == tree[j])
                {
                    oke = true;
                    Nodes.Add(i);
                }
                j++;
            }
            
        }
        return Nodes.Count; //Hieu ngu vl
        //throw new NotImplementedException("Waiting to be implemented.");
    }
}
