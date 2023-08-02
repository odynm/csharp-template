namespace Template.Contracts.Item
{
    public record CreateItemRequest(
        string Name,
        string Description,
        DateTime DueDate,
        List<string> SubItems
    );
}
