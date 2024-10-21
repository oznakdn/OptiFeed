namespace OptiFeed.Core.Models;

public class Animal
{
    public double Age { get; set; }            // Hayvanın yaşı
    public double LiveWeight { get; set; }     // Canlı ağırlık (kg)
    public double DailyMilkYield { get; set; } // Günlük süt verimi (litre)

    public double CalculateDryMatterRequirement()
    {
        // Genel bir formül: Canlı ağırlığın %3.5'i kadar kuru madde gereksinimi
        return LiveWeight * 0.035;
    }

    public double CalculateEnergyRequirement()
    {
        // Süt verimi başına enerji gereksinimi: 
        // (Günlük süt verimi başına 0.74 Mcal ve her 100 kg canlı ağırlık için 3 Mcal)
        return (DailyMilkYield * 0.74) + (LiveWeight / 100 * 3);
    }

    public double CalculateProteinRequirement()
    {
        // Süt verimi başına protein gereksinimi: 
        // (Günlük süt verimi başına 82 gram protein ve canlı ağırlık başına 0.8 gram protein)
        return (DailyMilkYield * 82) + (LiveWeight * 0.8);
    }
}
