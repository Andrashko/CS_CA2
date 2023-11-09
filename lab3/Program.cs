using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;
class Program
{
    public static void Main()
    {
        var papers = ReadFromXmlFile("./kiosk.xml");
        foreach (var paper in papers)
            Console.WriteLine(paper);
        Console.ReadLine();
    }

    private static List<Paper> ReadFromXmlFile(string FileName)
    {
        var papers = new List<Paper>();
        using (XmlTextReader reader = new XmlTextReader(FileName))
        {
            reader.ReadStartElement("papers");
            while (reader.Read())
            {
                if (reader.NodeType != XmlNodeType.Element || reader.Name != "paper")
                    continue;

                reader.ReadStartElement("paper");
                var paper = new Paper();

                reader.ReadStartElement("title");
                paper.Title = reader.Value.Trim();
                reader.Read();
                reader.ReadEndElement();

                reader.ReadStartElement("kind");
                var kind = reader.Value.Trim();
                if (kind == "magazine")
                    paper.Kind = PaperKind.Magazine;
                else if (kind == "newspaper")
                    paper.Kind = PaperKind.Newspaper;
                else
                    throw new XmlException($"Value '{kind}' is not allowed for paper.kind attribute");
                reader.Read();
                reader.ReadEndElement();

                reader.ReadStartElement("count");
                paper.Count = int.Parse(reader.Value.Trim());
                reader.Read();
                reader.ReadEndElement();

                reader.ReadStartElement("price");
                paper.Price = double.Parse(reader.Value.Trim());
                reader.Read();
                reader.ReadEndElement();

                papers.Add(paper);
            }
        }
        return papers;
    }
}
public enum PaperKind
{
    [Description("magazine")]
    Magazine,

    [Description("newspaper")]
    Newspaper
}
public class Paper
{
    public string Title;
    public PaperKind Kind;
    public int Count;
    public double Price;

    public override string ToString()
    {
        return $"{{\n\"Title\":\"{Title}\",\n\"Kind\":\"{Kind}\",\n\"Count\":\"{Count}\",\n\"Price\":\"{Price}\",\n}}";
    }
}
