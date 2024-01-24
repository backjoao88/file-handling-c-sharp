namespace FileHandling.Texts.FileStream;

/// <summary>
/// Handles simple text files using <see cref="StreamWriter"/> and <see cref="StreamReader"/>
/// </summary>
public class TextHandler
{
    private readonly string OutputPath;
    
    public TextHandler(string fileName)
    {
        OutputPath = Path.Combine(AppContext.BaseDirectory, fileName);
    }
    
    public async Task Write(string[] lines)
    {
        foreach(var line in lines)
        {
            StreamWriter stream = null!;
            try
            {
                stream = new(OutputPath, true);
                await stream.WriteAsync(line+"\n");
            }
            finally
            {
                await stream.DisposeAsync();
            }
        }
    }

    public async Task<string[]> ReadLines()
    {
        List<string> lines = new();
        if (lines == null) throw new ArgumentNullException(nameof(lines));
        StreamReader stream = null!;
        try
        {
            stream = new(OutputPath);
            while (!stream.EndOfStream)
            {
                var line = await stream.ReadLineAsync();
                if (line != null) lines.Add(line);
            }
        }
        finally
        {
            stream.Dispose();
        }
        return lines.ToArray();
    } 
    
}