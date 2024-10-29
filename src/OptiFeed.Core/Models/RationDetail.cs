namespace OptiFeed.Core.Models;

public class RationDetail
{
    public int Id { get; set; }
    public int RationId { get; set; }
    public List<RationFeedItem> FeedItems { get; set; } = new();
}
