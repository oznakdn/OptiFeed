namespace OptiFeed.Core.Result;

public class FeedMixResult
{
    public string FeedName { get; set; }
    public double PricePerKg { get; set; }
    public double UsagePercentage { get; set; }
    public double UsageAmountKg { get; set; }
    public double Cost { get; set; }
}

public class FeedMixSummary
{
    public List<FeedMixResult> FeedMixes { get; set; }
    public double TotalCost { get; set; }
}
