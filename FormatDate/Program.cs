using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class DateTransform
{
    public static List<string> TransformDateFormat(List<string> dates)
    {
        List<string> result = new List<string>();
        Regex date1 = new Regex(@"^\d{4}/\d{2}/\d{2}$");
        Regex date2 = new Regex(@"^\d{2}/\d{2}/\d{4}$");
        Regex date3 = new Regex(@"^\d{2}-\d{2}-\d{4}$");
        string[] data = new string[3];
        string swap = "";
        foreach(var item in dates)
        {
            if (date1.IsMatch(item))
            {
                result.Add(String.Join("",item.Split("/")));
                
            }
            else if (date2.IsMatch(item))
            {
                data = item.Split("/");
                swap = data[2];
                data[2] = data[0];
                data[0] = swap;
                result.Add(String.Join("", data));
            }
            else if(date3.IsMatch(item)) {
                data[0] = item.Split("-")[2];
                data[1] = item.Split("-")[0];
                data[2] = item.Split("-")[1];
                result.Add(String.Join("", data));
            }
        }
        return result;
    }
    public static void Main(string[] args)
    {
        var input = new List<string> { "2010/02/20", "19/12/2016", "11-18-2012", "20130720" };
        DateTransform.TransformDateFormat(input).ForEach(Console.WriteLine);
    }
}
