using Google.OrTools.LinearSolver;
using OptiFeed.Core.Models;
using OptiFeed.Core.Result;

namespace OptiFeed.BlazorWeb;

public class FeedMixer
{

    public static FeedMixSummary CalculateOptimalFeedMix(Animal animal, List<Feed> feeds)
    {

        double requiredDryMatter = animal.CalculateDryMatterRequirement();
        double requiredEnergy = animal.CalculateEnergyRequirement();
        double requiredProtein = animal.CalculateProteinRequirement();
        double requiredAdf = animal.CalculateADFRequirement();
        double requiredNdf = animal.CalculateNDFRequirement();


        Solver solver = Solver.CreateSolver("GLOP");

        if (solver == null)
        {
            return default!;
        }
        
        List<Variable> feedVars = new List<Variable>();
        foreach (var feed in feeds)
        {
            var variable = solver.MakeNumVar(
                feed.MinUsage / 100 * animal.CalculateDryMatterRequirement(),
                feed.MaxUsage / 100 * animal.CalculateDryMatterRequirement(), 
                feed.Name);

            feedVars.Add(variable);
        }

       
        Constraint dryMatterConstraint = solver.MakeConstraint(requiredDryMatter, double.PositiveInfinity, "DryMatter");
        for (int i = 0; i < feeds.Count; i++)
        {
            dryMatterConstraint.SetCoefficient(feedVars[i], feeds[i].DryMatter / 100);  // % kuru madde oranını kullan
        }

        Constraint energyConstraint = solver.MakeConstraint(requiredEnergy, double.PositiveInfinity, "Energy");
        for (int i = 0; i < feeds.Count; i++)
        {
            energyConstraint.SetCoefficient(feedVars[i], feeds[i].EnergyContent);
        }

        Constraint proteinConstraint = solver.MakeConstraint(requiredProtein, double.PositiveInfinity, "Protein");
        for (int i = 0; i < feeds.Count; i++)
        {
            proteinConstraint.SetCoefficient(feedVars[i], feeds[i].ProteinContent);
        }

        Constraint adfConstraint = solver.MakeConstraint(requiredAdf, double.PositiveInfinity, "ADF");
        for (int i = 0; i < feeds.Count; i++)
        {
            adfConstraint.SetCoefficient(feedVars[i], feeds[i].ADFContent);
        }

        Constraint ndfConstraint = solver.MakeConstraint(requiredNdf, double.PositiveInfinity, "NDF");
        for (int i = 0; i < feeds.Count; i++)
        {
            ndfConstraint.SetCoefficient(feedVars[i], feeds[i].NDFContent);
        }

        
        Objective objective = solver.Objective();
        for (int i = 0; i < feeds.Count; i++)
        {
            objective.SetCoefficient(feedVars[i], feeds[i].CostPerKg);
        }
        objective.SetMinimization();

       
        Solver.ResultStatus resultStatus = solver.Solve();

        
        var feedMixSummary = new FeedMixSummary { FeedMixes = new List<FeedMixResult>(), TotalCost = 0 };

        if (resultStatus == Solver.ResultStatus.OPTIMAL)
        {
            Console.WriteLine("Optimal çözüm bulundu.");
            double totalCost = 0;
            double totalDryMatterUsed = feedVars.Zip(feeds, (v, f) => v.SolutionValue() * f.DryMatter).Sum();

            for (int i = 0; i < feeds.Count; i++)
            {
                double feedUsageAmount = feedVars[i].SolutionValue();
                if (feedUsageAmount > 0)
                {
                    
                    double usagePercentage = (feedUsageAmount * feeds[i].DryMatter) / totalDryMatterUsed * 100;
                    double cost = feedUsageAmount * feeds[i].CostPerKg;

                    feedMixSummary.FeedMixes.Add(new FeedMixResult
                    {
                        FeedName = feeds[i].Name,
                        PricePerKg = feeds[i].CostPerKg,
                        UsagePercentage = usagePercentage,
                        UsageAmountKg = feedUsageAmount,
                        Cost = cost
                    });

                    totalCost += cost;
                }
            }

            feedMixSummary.TotalCost = totalCost;
        }
        else
        {
            Console.WriteLine("Optimal çözüm bulunamadı.");
        }

        return feedMixSummary;
    }

}
