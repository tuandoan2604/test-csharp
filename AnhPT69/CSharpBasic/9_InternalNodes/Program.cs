using System;
using System.Collections.Generic;

public class InternalNodes
{
    public static int Count(params int[] tree)
    {
        int n = tree.Length;
        Dictionary<int,int> Nodes = new Dictionary<int,int>();

        for (int i = 0; i < n; i++)
        {
            if (Nodes.ContainsKey(tree[i]))
            {
                Nodes[tree[i]]++;
            }
            else
            {
                Nodes.Add(tree[i], 1);
            }    

        }
        return Nodes.Count - 1;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(InternalNodes.Count(1, 3, 1, -1, 3, 6, -1, 8, 6, 5));
    }
}
