using System.Text.Json;
using System.ComponentModel;

class Program
{
    public static void Main()
    {
        using (var reader = new StreamReader("./kiosk.json"))
        {
            var s = reader.ReadToEnd();
            var papers = JsonSerializer.Deserialize<List<PaperDTO>>(s);
            foreach (var paper in papers)
                Console.WriteLine(paper);
        }
        Console.ReadLine();
    }


}
public enum PaperKind
{
    [Description("magazine")]
    Magazine,

    [Description("newspaper")]
    Newspaper
}

public class PaperDTO
{
    public string Title { get; set; }
    public string Kind { get; set; }
    public int Count { get; set; }
    public string Price;
}
public class Paper
{
    public string Title;
    public string Kind;
    // public int Count;
    // public double Price;

    // public override string ToString()
    // {
    //     return $"{{\n\"Title\":\"{Title}\",\n\"Kind\":\"{Kind}\",\n\"Count\":{Count},\n\"Price\":{Price}\n}}";
    // }
}
