// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System.Collections;
using System.Security.AccessControl;

//int[] arr = new int[] { 5, 4, 3, 2, 1, 5, 4, 3, 2, 5, 4, 3, 5, 4, 5 };

int[] arr = new int[100];

for (int i = 0; i < 100; i++)
{
    Random rand = new Random();
    arr[i] = rand.Next(1,6);
}

int x = BookSale.NthLowestSelling(arr, 2);
Console.WriteLine("Result: " + x);
Console.ReadLine();

public class BookSale
{
    public static int NthLowestSelling(int[] sales, int n)
    {
        Hashtable table = new Hashtable();
       
        for (int i = 0; i < sales.Count(); i++ )
        {
            if (table.ContainsKey(sales[i].ToString()))
            {
                table[sales[i].ToString()] = (int)table[sales[i].ToString()] + 1;
            }
            else
            {
                table.Add(sales[i].ToString(), 1);
            }    
        }


        List<DictionaryEntry> list = new List<DictionaryEntry>();
        foreach (DictionaryEntry item in table)
        {
            list.Add(item);
        }

        list.Sort((x, y) => ((int)x.Value).CompareTo((int)y.Value));

        /*foreach (DictionaryEntry item in table)
        {
            Console.Write("{0}: {1}  -   ", item.Key, item.Value);
        }*/

        return int.Parse(list[n-1].Key.ToString());

        //throw new InvalidOperationException("Waiting to be implemented.");
    }
}
