using System;
using System.Collections.Generic;

public class FlightConnections
{
    public static int[] dd = new int[1000]; 
    public static int dem = 1, dem2 = 0;
    public static void BFS(bool[,] a, int n, int i)
    {
        dd[i] = 1; 
        for (int j = 0; j < n; j++)
        {
            if (a[i, j] != false && dd[j] == 0)
            {
                dem++;
                BFS(a, n, j); 
            }
        }
    }
    public static int GetMinimumConnections(bool[,] matrix)
    {
        BFS(matrix, matrix.GetLength(0), 0);
        if(dem == matrix.GetLength(0))
        {
            return 0;
        }
        else
        {
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (dd[i] == 0) 
                {
                    BFS(matrix, matrix.GetLength(0), i); ; 
                    dem2++;
                }
            }
            return dem2--;
        }
    }

    public static void Main(string[] args)
    {
        bool[,] matrix = new bool[,]
        {
            {false, true, false, false, true},
            {true, false, false, false, false},
            {false, false, false, true, false},
            {false, false, true, false, false},
            {true, false, false, false, false}
        };
        Console.WriteLine(GetMinimumConnections(matrix)); 
    }
}
