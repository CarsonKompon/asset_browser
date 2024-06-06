namespace Browser;

public interface IInspector
{
    public BaseFileSystem FileSystem { get; set; }
    public string Path { get; set; }
}