using System;
using System.Collections.Generic;

public class DateTransform
{
    public static List<string> TransformDateFormat(List<string> dates)
    {
        dynamic data, swap;
        string[] dataTime = new string[3];
        List<string> result = new List<string>();
        foreach(var item in dates)
        {
            if (item.Contains("/"))
            {
                data = item.Split("/");
                if (data[0].Length == 4 && data[1].Length == 2 && data[2].Length == 2)
                {
                    result.Add(String.Join("", data));
                }
                else if (data[0].Length == 2 && data[1].Length == 2 && data[2].Length == 4)
                {
                    swap = data[0];
                    data[0] = data[2];
                    data[2] = swap;
                    result.Add(String.Join("", data));    
                }
            }
            else if (item.Contains("-"))
            {
                data = item.Split("-");
                if (data[0].Length == 2 && data[1].Length == 2 && data[2].Length == 4)
                {
                    dataTime[0] = data[2];
                    dataTime[1] = data[0];
                    dataTime[2] = data[1];
                    result.Add(String.Join("", dataTime));
                }
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
