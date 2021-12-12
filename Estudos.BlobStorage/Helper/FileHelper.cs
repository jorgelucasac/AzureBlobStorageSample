namespace Estudos.BlobStorage.Helper;

public static class FileHelper
{
    public static string GetUniqueName(string name)
    {
        return $"{Guid.NewGuid()}_{name}";
    }
}