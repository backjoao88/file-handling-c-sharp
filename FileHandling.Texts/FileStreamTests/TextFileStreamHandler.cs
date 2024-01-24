using System.Text;

namespace FileHandling.Texts.FileStreamTests;

/// <summary>
/// Handles simple text files
/// </summary>
public class TextFileStreamHandler
{
    public TextFileStreamHandler(string fileName)
    {
        string outputPath = Path.Combine(AppContext.BaseDirectory, fileName);
        _stream = new System.IO.FileStream(outputPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite, 4096);
    }

    private readonly System.IO.FileStream _stream;

    public async Task Write(string[] lines)
    {
        foreach (var line in lines)
        {
            byte[] lineBytes = Encoding.UTF8.GetBytes(line + "\n");
            await _stream.WriteAsync(new ReadOnlyMemory<byte>(lineBytes));
            await _stream.FlushAsync();
        }
    }
    public async Task<string[]> ReadLines()
    {
        byte[] buffer = new byte[_stream.Length];
        // Using the same stream, we need to set Position = 0.
        // Because in writting we had moved the file bytes pointer forward.
        // So, to read correctly all lines, need to be set to 0.
        Console.WriteLine(_stream.Position);
        var _ = await _stream.ReadAsync(buffer, 0, (int)_stream.Length);
        string content = Encoding.UTF8.GetString(buffer);
        return content.Split("\n");
    }
}