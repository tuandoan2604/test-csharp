using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class DateTransform
{
    public static List<string> TransformDateFormat(List<string> dates)
    {
        List<string> result = new List<string>();

        var regex1 = new Regex(@"^(\d{4})(/|-)(0[1-9]|1[0-2])(/|-)(0[1-9]|[1-2][0-9]|3[0-1])$"); // Matches "yyyy/MM/dd"
        var regex2 = new Regex(@"^(0[1-9]|[1-2][0-9]|3[0-1])(/|-)(0[1-9]|1[0-2])(/|-)(\d{4})$"); // Matches "dd/MM/yyyy"
        var regex3 = new Regex(@"^(0[1-9]|1[0-2])(/|-)(0[1-9]|[1-2][0-9]|3[0-1])(/|-)(\d{4})$"); // Matches "MM/dd/yyyy"

        for (int i = 0; i < dates.Count; i++)
        {
            var match1 = regex1.Match(dates[i]);
            var match2 = regex2.Match(dates[i]);
            var match3 = regex3.Match(dates[i]);

            if (match1.Success)
            {
                result.Add(match1.Groups[1].Value + match1.Groups[3].Value + match1.Groups[5].Value);
            }
            else if (match2.Success)
            {
                result.Add(match2.Groups[5].Value + match2.Groups[3].Value + match2.Groups[1].Value);
            }
            else if (match3.Success)
            {
                result.Add(match3.Groups[5].Value + match3.Groups[1].Value + match3.Groups[3].Value);
            }   
        }
        return result;
    }
    public static void Main(string[] args)
    {
        var dates = new List<string> { "2010/02/20", "19/12/2016", "11-18-2012", "20130720", "10-30-2012" };
        DateTransform.TransformDateFormat(dates).ForEach(Console.WriteLine);
    }
}
