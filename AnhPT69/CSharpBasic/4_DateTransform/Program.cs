// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

var input = new List<string> { "2010/02/20", "19/12/2016", "11-18-2012", "20130720" };
DateTransform.TransformDateFormat(input).ForEach(Console.WriteLine);
Console.ReadLine();

public class DateTransform
{
    public static List<string> TransformDateFormat(List<string> dates)
    {
        string str = "";
        List<int> nchar = new List<int> { };
        List<string> output = new List<string>();
        int n = dates.Count;

        string strpl1 = "", strpl2 = "", strpl3 = "";
         

        for (int i = 0; i < n; i++)
        {
            str = dates[i];

            for (int j = 0; j < str.Length; j++)
            {
                if (!char.IsDigit(str[j]))
                {
                    nchar.Add(j);
                }
            }

            if (nchar.Count > 1)
            {
                strpl1 = str.Substring(0, nchar[0]);
                strpl2 = str.Substring(nchar[0] + 1, (nchar[1] - nchar[0] - 1));
                strpl3 = str.Substring(nchar[1] + 1, (str.Length - nchar[1] - 1));

                str = GetStr(strpl1, strpl2, strpl3);

                output.Add(str);
                
            }
            else
            {
                nchar.Clear();
                continue;
            }
            
            //Console.WriteLine(str);
            nchar.Clear();
        }

        return output;

        //throw new InvalidOperationException("Waiting to be implemented.");
    }

    public static string GetStr(string str1, string str2, string str3)
    {
        string str;
        if (int.Parse(str1) > 31)
        {
            if (int.Parse(str2) > 12)
            {
                str = str1 + str3 + str2;
            }
            else
            {
                str = str1 + str2 + str3;
            }
        }
        else if (int.Parse(str3) > 31)
        {
            if (int.Parse(str2) > 12)
            {
                str = str3 + str1 + str2;
            }
            else
            {
                str = str3 + str2 + str1;
            }
        }
        else
        {
            if (int.Parse(str3) > 12)
            {
                str = str2 + str1 + str3;
            }
            else
            {
                str = str2 + str3 + str1;
            }
        }

        return str;
    }
}


