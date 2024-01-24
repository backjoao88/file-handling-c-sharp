using System.Text;

namespace FileHandling.Streams.MemoryStreamTests;

public class Program
{
    public static void MemoryStreamTests()
    {
        const int StreetOffset = 0;
        const int StreetLength = 48;
        const int StateOffset = 49;
        const int StateLength = 16;
        byte[] buffer = new byte[StreetLength + StateLength];
        MemoryStream memoryStream = new MemoryStream(buffer);
        var streetValue = "RUA";
        var stateValue = "SC";
        memoryStream.Write(Encoding.UTF8.GetBytes(streetValue));
        memoryStream.Write(Encoding.UTF8.GetBytes(stateValue));
        memoryStream.Position = 0;
        Console.WriteLine((char)memoryStream.ReadByte());
        Console.WriteLine((char)memoryStream.ReadByte());
        Console.WriteLine((char)memoryStream.ReadByte());
        Console.WriteLine((char)memoryStream.ReadByte());
        Console.WriteLine((char)memoryStream.ReadByte());
    }

    public static void Main(string[] args)
    {
        MemoryStreamTests();
    }
}