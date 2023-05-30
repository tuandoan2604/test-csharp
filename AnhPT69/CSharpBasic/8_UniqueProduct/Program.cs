using System;
using System.Collections;
using System.Collections.Generic;

public class UniqueProduct
{
    public static string FirstUniqueProduct(string[] products)
    {
        Dictionary<string, int> countMap = new Dictionary<string, int>();
        
        string result = string.Empty;

        foreach (string pro in products)
        {
            if (countMap.ContainsKey(pro))
            {
                countMap[pro]++;
            }
            else
            {
                countMap.Add(pro, 1);
            }
        }

        foreach (string pro in products)
        {
            if (countMap[pro] == 1)
            {
               result = pro;
                break;
            }
        }

        return result;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(FirstUniqueProduct(new string[] { "Apple", "Computer", "Apple", "Bag" }));
    }
}
