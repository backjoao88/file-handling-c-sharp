namespace FileHandling.Texts.BinaryStreamTests;

public class Program
{
    public static void BinaryStreamTests()
    {
        BinaryFileStreamHandler binaryFileStreamHandler = new BinaryFileStreamHandler("test.dat");
        binaryFileStreamHandler.Write("oi");
        char[] chars = binaryFileStreamHandler.Read();
        var messageComplete = string.Join("", chars);
        Console.WriteLine(messageComplete);  
    }
}