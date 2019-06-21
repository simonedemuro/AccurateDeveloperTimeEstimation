using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ADE.Domain.Models;
using ADE.Domain.ViewModels;
using System.Linq;
using ADE.Engine.Utils;

namespace ADE.Engine
{
    public class DistributionManager
    {
        Object lockMe = new Object();
        double TotalExpectedDuration;
        double TotalStandardDeviation;
        private List<PertVM> pertVMs = new List<PertVM>();

        public DistributionManager(List<PertInput> pertInputs)
        {
            CalculateBetaDistributionAndDeviationItems(pertInputs);
        }

        public double LikelihoodCompleteWithinDays(double expectedNumberOfDays)
        {
           

            double Zvalue = (expectedNumberOfDays - TotalExpectedDuration) / TotalStandardDeviation;
            double NormalDistribution = NormalDistributionHelper.NORMSDIST(Zvalue);

            return NormalDistribution * 100;
        }

        public List<ProjectCompletionOdds> GetProjectCompletionOdds()
        {
            List<ProjectCompletionOdds> projectCompletionOdds = new List<ProjectCompletionOdds>()
            {
                new ProjectCompletionOdds("10%", TotalExpectedDuration - TotalStandardDeviation),
                new ProjectCompletionOdds("50%", TotalExpectedDuration),
                new ProjectCompletionOdds("20%", TotalExpectedDuration + TotalStandardDeviation),
                new ProjectCompletionOdds("10%", TotalExpectedDuration + 2 * TotalStandardDeviation),
                new ProjectCompletionOdds("5%",  TotalExpectedDuration + 3 * TotalStandardDeviation),
                new ProjectCompletionOdds("2%", TotalExpectedDuration + 4 * TotalStandardDeviation),
                new ProjectCompletionOdds("< 1%", TotalExpectedDuration + 5 * TotalStandardDeviation)

            };
            return projectCompletionOdds;
        }

        private void CalculateBetaDistributionAndDeviationItems(List<PertInput> pertInputs)
        {
            Parallel.ForEach(pertInputs, input =>
            {
                lock (lockMe)
                {
                    pertVMs.Add(DistributionManagerUtils.CalculateBetaDistributionAndDeviationLineItems(input));
                }
            });
            TotalExpectedDuration = pertVMs.Select(x => x.ExpectedDurationTask).Sum();
            TotalStandardDeviation = Math.Sqrt(pertVMs.Select(x => Math.Pow(x.StandardDeviation, 2)).Sum());
        }


    }
}
