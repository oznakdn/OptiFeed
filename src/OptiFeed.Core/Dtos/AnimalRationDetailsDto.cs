namespace OptiFeed.Core.Dtos;

public class AnimalRationDetailsDto : AnimalRationDto
{
    public List<FeedItemsDto> FeedItems { get; set; } = new();
}

public class FeedItemsDto
{
    public string FeedName { get; set; }
    public double PricePerKg { get; set; }
    public double UsagePercentage { get; set; }
    public double UsageAmountKg { get; set; }
}