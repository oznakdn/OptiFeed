namespace OptiFeed.Core.Models;

public class Animal
{
    public double LiveWeight { get; set; }     // Canlı ağırlık (kg)
    public double DailyMilkYield { get; set; } // Günlük süt verimi (litre)
    public double MilkFat { get; set; }       // Süt yağ oranı
    public double MilkProtein { get; set; }   // Süt protein oranı

    public double CalculateDryMatterRequirement()
    {
        // Genel bir formül: Canlı ağırlığın %3.5'i kadar kuru madde gereksinimi
        return (0.0245 * LiveWeight) + (0.305 * DailyMilkYield);

    }

    public double CalculateEnergyRequirement()
    {
        double NEm = 0.086 * Math.Pow(LiveWeight, 0.75); // Bakım enerjisi
        double NEl = 0.0929 * DailyMilkYield * (0.054 * MilkFat + 0.39); // Süt üretimi enerjisi
        return NEm + NEl;
    }

    public double CalculateProteinRequirement()
    {
        double MP_m = 3.8 * Math.Pow(LiveWeight, 0.75); // Bakım protein ihtiyacı
        double MP_l = 0.85 * DailyMilkYield * MilkProtein == 0 ? 1 : MilkProtein;  // Süt üretimi protein ihtiyacı
        return MP_m + MP_l;
    }

    public double CalculateADFRequirement()
    {
        return CalculateDryMatterRequirement() * 0.20; // %20 ADF gereksinimi örnek olarak alındı
    }

    public double CalculateNDFRequirement()
    {
        return CalculateDryMatterRequirement() * 0.30; // %30 NDF gereksinimi örnek olarak alındı
    }
}
