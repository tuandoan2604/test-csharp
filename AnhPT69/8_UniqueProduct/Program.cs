// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System.Runtime.Serialization.Formatters;

string[] str = new string[] { "Apple", "Computer", "Apple", "Bag" };
string result = UniqueProduct.FirstUniqueProduct(str);
Console.WriteLine("Result: " + result);
Console.ReadLine();


public class UniqueProduct
{
    public static string FirstUniqueProduct(string[] products)
    {
        int n = products.Length;
        string temp = "";
        bool oke = false;
        for (int i = 0; i < n; i++)
        {
            temp = products[i];
            for (int j = i + 1; j < n; j++)
            {
                if (products[j] == temp)
                {
                    break;
                }
                else if (j == n - 1) {
                    oke = true;
                }

            }
            if (oke)
            {
                break;
            }  
        }
        return temp;


        //throw new InvalidOperationException("Waiting to be implemented.");
    }
}