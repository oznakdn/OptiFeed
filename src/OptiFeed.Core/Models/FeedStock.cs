namespace OptiFeed.Core.Models;

public class FeedStock
{
    public int Id { get; set; }
    public int FeedId { get; set; }
    public double Amount { get; set; }

    public Feed? Feed { get; set; }
}
