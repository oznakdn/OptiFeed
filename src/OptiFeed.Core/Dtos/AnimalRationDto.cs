namespace OptiFeed.Core.Dtos;

public class AnimalRationDto
{
    public int RationId { get; set; }
    public string AnimalName { get; set; }
    public string? TagNumber { get; set; }
    public double TotalCost { get; set; }
}