using System;
using System.Collections;
using System.Collections.Generic;

public class LogParser
{
    public static IEnumerable<long> GetTimestampsByDescription(string xml, string description)
    {
        string[] s = xml.Split("\"");
        for(int i = 0; i < s.Length; i++)
        {
            if (s[i].Contains(description))
            {
                yield return long.Parse(s[i-1]);
            }

        }
    }

    public static void Main(string[] args)
    {
        string xml =
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
                "<log>\n" +
                "    <event timestamp=\"1614285589\">\n" +
                "        <description>Intrusion detected</description>\n" +
                "    </event>\n" +
                "    <event timestamp=\"1614286432\">\n" +
                "        <description>Intrusion ended</description>\n" +
                "    </event>\n" +
                "</log>";

        foreach (long timestamp in LogParser.GetTimestampsByDescription(xml, "Intrusion ended"))
        {
            Console.WriteLine(timestamp);
        }
    }
}
