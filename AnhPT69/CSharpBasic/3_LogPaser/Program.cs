using System.Collections;
using System.Xml;

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

string des = "Intrusion ended";

foreach (long timestamp in LogParser.GetTimestampsByDescription(xml, des))
    Console.WriteLine($"{des} in timestamp:  {timestamp}");

Console.ReadLine();


public class LogParser
{
    public static IEnumerable<long> GetTimestampsByDescription(string xml, string description)
    {
        XmlDocument Doc = new XmlDocument();
        Doc.LoadXml(xml);

        XmlNodeList LogList = Doc.SelectNodes("//event");

        foreach (XmlNode node in LogList)
        {
            string ts = node.Attributes["timestamp"].Value;
            string dt = node.SelectSingleNode("description").InnerText;

            if (dt == description)
            {
                yield return long.Parse(ts);
            }

        }

            //throw new NotImplementedException("Waiting to be implemented.");
    }  
}
