namespace Estudos.BlobStorage.Helper;

public static class FileHelper
{
    public static string GetUnicName(string name)
    {
        return $"{Guid.NewGuid()}_{name}";
    }
}