namespace FileHandling.Streams.BinaryStreamTests;

public class BinaryFileStreamHandler
{
    private readonly string OutputPath;
    public BinaryFileStreamHandler(string fileName)
    {
        OutputPath = Path.Combine(AppContext.BaseDirectory, fileName);
    }

    public void Write(string message)
    {
        using BinaryWriter binaryWriter = new BinaryWriter(new System.IO.FileStream(OutputPath, FileMode.OpenOrCreate, FileAccess.ReadWrite));
        foreach (var cchar in message)
        {
            binaryWriter.Write((byte) cchar);
        }
    }
    
    public char[] Read()
    {
        List<char> message = new List<char>();
        if (message == null) throw new ArgumentNullException(nameof(message));
        FileInfo file = new FileInfo(OutputPath);
        using BinaryReader binaryWriter = new BinaryReader(new System.IO.FileStream(OutputPath, FileMode.OpenOrCreate, FileAccess.ReadWrite));
        var bytes = binaryWriter.ReadBytes((int)file.Length);
        foreach (var cchar in bytes)
        {
            message.Add((char) cchar);
        }
        return message.ToArray();
    }
}