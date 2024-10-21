namespace OptiFeed.Core.Models;

public class Feed
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double DryMatter { get; set; }      // % Dry matter (Kuru Madde)
    public double EnergyContent { get; set; }  // Mcal/kg
    public double ProteinContent { get; set; } // g/kg
    public double CostPerKg { get; set; }      // Cost in $ per kg
    public double MaxUsage { get; set; }       // Max kg that can be used in the ration
}
