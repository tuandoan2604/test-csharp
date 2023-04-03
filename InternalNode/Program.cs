using System;
using System.Collections.Generic;

public class InternalNodes
{
    public static int count;
    public static int node;
    public static int valueTree = 0;
    public static void CountNode(int node, int[] tree)
    {
        
            for(int i = 0; i < tree.Length; i++)
            {
                if (tree[i] == node)
                {
                    count++;
                    CountNode(i, tree);
                }
            }
    }
    public static int Count(params int[] tree)
    {
        for(int i = 0; i < tree.Length; i++)
        {
            if (tree[i] == -1) { 
                count++;
                node = i;
            }
        }
        CountNode(node, tree);
        return count;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(InternalNodes.Count(1, 3, 1, -1, 3));
    }
}