namespace OptiFeed.Core.Models;

public class RationFeedItem
{
    public int Id { get; set; }
    public int RationDetailId { get; set; }
    public string FeedName { get; set; }
    public double PricePerKg { get; set; }
    public double UsagePercentage { get; set; }
    public double UsageAmountKg { get; set; }

    public RationDetail? RationDetail { get; set; }

}
