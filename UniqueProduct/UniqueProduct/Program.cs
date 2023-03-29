using System;
using System.Collections.Generic;

public class UniqueProduct
{
    public static string FirstUniqueProduct(string[] products)
    {
        int bien_dem = 0;
        int i, j, k;
        for (i = 0; i < products.Length; i++)
        {
            bien_dem = 0;
            for (j = 0; j < i - 1; j++)
            {
                if (products[i] == products[j])
                {
                    bien_dem++;
                }
            }
            for (k = i + 1; k < products.Length; k++)
            {
                if (products[i] == products[k])
                {
                    bien_dem++;
                }
            }
            if(bien_dem == 0)
            {
                return products[i];
                break;
            }
        }
        return "";
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(FirstUniqueProduct(new string[] { "Apple", "Computer", "Apple", "Bag" }));
    }
}
