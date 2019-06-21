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
        private List<PertVM> pertVMs = new List<PertVM>();

        public DistributionManager(List<PertInput> pertInputs)
        {
            CalculateBetaDistributionAndDeviationItems(pertInputs);
        }

        public double LikelihoodCompleteWithinDays(double expectedNumberOfDays)
        {
            double TotExpectedDuration = pertVMs.Select(x => x.ExpectedDurationTask).Sum();
            double TotalStandardDeviation = Math.Sqrt(pertVMs.Select(x => Math.Pow(x.StandardDeviation,2)).Sum());

            double Zvalue = (expectedNumberOfDays - TotExpectedDuration) / TotalStandardDeviation;
            double NormalDistribution = NormalDistributionHelper.NORMSDIST(Zvalue);

            return NormalDistribution * 100;
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
        }
    }
}
