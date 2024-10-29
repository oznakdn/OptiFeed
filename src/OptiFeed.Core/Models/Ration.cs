namespace OptiFeed.Core.Models;

public class Ration
{
    public int Id { get; set; }
    public int AnimalId { get; set; }
    public RationDetail? RationDetail { get; set; }
}
