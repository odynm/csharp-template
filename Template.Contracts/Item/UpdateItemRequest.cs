namespace Template.Contracts.Item
{
    public record UpdateItemRequest(
        string Name,
        string Description,
        DateTime DueDate,
        DateTime LastModified,
        List<string> SubItems
    );
}
