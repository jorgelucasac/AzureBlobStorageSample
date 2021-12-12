namespace Estudos.BlobStorage.Models;

public class BlobItemResponse
{
    public string Name { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public long? Length { get; set; }
    public DateTimeOffset? LastModified { get; set; }
}