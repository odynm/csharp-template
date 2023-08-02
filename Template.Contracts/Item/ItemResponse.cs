namespace Template.Contracts.Item
{
    public record ItemResponse(
        Guid id,
        string Name,
        string Description,
        DateTime DueDate,
        DateTime LastModified,
        List<string> SubItems
    );
}
