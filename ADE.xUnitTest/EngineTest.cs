using ADE.Domain.Models;
using ADE.Domain.ViewModels;
using ADE.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ADE.xUnitTest
{
    public class EngineTest
    {
        DistributionManager distributionManager;
        List<PertInput> pertInputs = new List<PertInput>()
            {
                new PertInput()
                {
                    Optimistic = 1,
                    Neutral = 3,
                    Pessimistic = 12
                },
                new PertInput()
                {
                    Optimistic = 1,
                    Neutral = 1.5,
                    Pessimistic = 14
                },
                new PertInput()
                {
                    Optimistic = 3,
                    Neutral = 6.25,
                    Pessimistic = 11
                }
            };
        public EngineTest()
        {
            distributionManager = new DistributionManager(pertInputs);
        }

        [Fact]
        public void HowLikelyIsToCompleteATaskWithinNDays()
        {

            double odds = distributionManager.LikelihoodCompleteWithinDays(15);

            Assert.True(DifferenceNotExcedesTolerance(odds, 60, 1));

        }

        [Fact]
        public void ProjectOdds()
        {
            List<ProjectCompletionOdds> projOdds = distributionManager.GetProjectCompletionOdds();
            Assert.True(projOdds.Any());
        }

        private static bool DifferenceNotExcedesTolerance(double odds, double expectedVal, double tollerance)
        {
            return Math.Abs(expectedVal - odds) < tollerance;
        }


    }
}
