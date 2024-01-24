using FileHandling.Texts.FileStream;

namespace FileHandling.Texts.FileStreamTests;

/// <summary>
/// This program is responsible to build simple texts files.
/// </summary>
public class Program
{

    public static async Task HandleWithTextStream()
    {
        TextHandler textHandler = new TextHandler("teste.txt");
        await textHandler.Write(new string[] { "joao", "teste", "kaio" });
        string[] lines = await textHandler.ReadLines();
        foreach (var line in lines)
        {
          Console.WriteLine(line);
        }
    }

    public static async Task HandleWithFileStream()
    {
        TextFileStreamHandler textFileStreamHandler = new TextFileStreamHandler("teste.txt");
        await textFileStreamHandler.Write(new string[] { "OI", "TESTE" });
        string[] lines = await textFileStreamHandler.ReadLines();
        foreach (var line in lines)
        {
            Console.WriteLine(line);
        }
    }
    
    // public static async Task Main(string[] args)
    // {
    //     await HandleWithTextStream();
    // }
}