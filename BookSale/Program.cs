using System;
using System.Collections.Generic;
using System.Threading;

public class BookSale
{
    public static SortedList<int, int> data = new SortedList<int, int>();
    public static int value { get; set; }
    public static int revenue { get; set; }
    public BookSale()
    {
        data = new SortedList<int, int>();
    }
    public static int NthLowestSelling(int[] sales, int n)
    {
        for (int i = 0; i < sales.Length; i++)
        {
            if (sales[i] != -1)
            {
                value = sales[i];
                revenue++;
                for (int j = i + 1; j < sales.Length; j++)
                {
                    if (sales[j] == sales[i])
                    {
                        sales[j] = -1;
                        revenue++;
                    }
                }
                data.Add(sales[i], revenue);
                sales[i] = -1;
                revenue = 0;
            }
            

        }
        foreach(var item in data.Keys)
        {
            if (data[item] > n - 1)
            {
                return item;
            }
        }
        return 0;
    }

    public static void Main(string[] args)
    {
        int x = NthLowestSelling(new int[] { 5, 4, 3, 2, 1, 5, 4, 3, 2, 5, 4, 3, 5, 4, 5 }, 5);
        Console.WriteLine(x);
    }
}
